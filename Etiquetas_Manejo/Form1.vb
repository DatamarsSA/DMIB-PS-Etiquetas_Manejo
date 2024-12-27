Imports BaiqiSoft.LabelControl
Imports RestSharp

Public Class Form1

    'Dim btApp As New BarTender.Application
    Dim miRest As New MyRestServer
    Dim setting As String = System.AppDomain.CurrentDomain.BaseDirectory
    Dim IP_Local As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim ip As System.Net.IPHostEntry
        ip = System.Net.Dns.GetHostEntry(My.Computer.Name)
        Dim i As Integer = ip.AddressList.Length
        Dim str As String
        'ctes.Equipo = INIRead(setting & "\settings.ini", ip.AddressList(i - 1).ToString, "Nombre", "")
        For j = 0 To i - 1
            ctes.Equipo = INIRead(setting & "\settings.ini", ip.AddressList(j).ToString, "Nombre", "")
            IP_Local = ip.AddressList(j).ToString
            If ctes.Equipo <> "" Then
                Exit For
            End If
        Next
        Me.Text = "ETIQUETAS MANEJO - " & ctes.Equipo
        Try
            miRest.openRestServer()
            lblPSStatus.BackColor = Color.LightGreen
            lblPSStatus.Text = "Conectado a PS"
            AddHandler miRest.receivedOrder, AddressOf ReceivedOrderFromPS
        Catch ex As Exception
            lblPSStatus.BackColor = Color.Red
            lblPSStatus.Text = "NO conectado a PS"
        End Try

        Dim ImpDefecto As New System.Drawing.Printing.PrinterSettings
        cmbImpresora.Text = INIRead(My.Application.Info.DirectoryPath & "\settings.ini", "Impresora", "Impresora", ImpDefecto.PrinterName)

    End Sub

    Private Sub ReceivedOrderFromPS()

        'Dim btlabel As BarTender.Format = btApp.Formats.Open(My.Application.Info.DirectoryPath & "\Etiqueta_ITACA.btw")
        ''EN FUNCIÓN DEL TIPO DE PEDIDO QUE SE HAYA CARGADO SE SACA UNA PEGATINA SIMPLE O DOBLE (SOLO ITACA)
        ''PARA ITACA TENEMOS QUE IMPRIMIR DOS ETIQUETAS, UNA PARA EL MACHO (PEDIDO-M) Y OTRA PARA LA HEMBRA (PEDIDO-H)
        'If ctes.Tipo = "ITACA" Then
        '    btlabel.SetNamedSubStringValue("numPedido", ctes.receivedWO.ProdLineItemNum & "-M")
        'Else
        '    btlabel.SetNamedSubStringValue("numPedido", ctes.receivedWO.ProdLineItemNum)
        'End If
        ''PARA LOS LECTORES SE USA LA PEGATINA DE LOTE, POR LO QUE SACAMOS MENOS DATOS
        'If ctes.Tipo = "LECTORES" Then
        '    btlabel.SetNamedSubStringValue("producto", ctes.receivedWO.ComponentSet.Split(",")(1))
        '    btlabel.SetNamedSubStringValue("nombreDelegacion", GetDelegacion(ctes.receivedWO.OrderInformation.Address))
        '    btlabel.SetNamedSubStringValue("fecha", Now.Date)
        'Else
        '    btlabel.SetNamedSubStringValue("nombreCliente", ctes.receivedWO.OrderInformation.Customer)
        '    btlabel.SetNamedSubStringValue("producto", ctes.receivedWO.ComponentSet.Split(",")(1))
        '    btlabel.SetNamedSubStringValue("nombreGanadero", GetGanadero(ctes.receivedWO.Notes))
        '    btlabel.SetNamedSubStringValue("nombreDelegacion", GetDelegacion(ctes.receivedWO.OrderInformation.Address))
        '    btlabel.SetNamedSubStringValue("fecha", Now.Date)
        'End If

        ''CARGAMOS LAS LABELS DEL FORM
        'Cargar_datos_pedido(ctes.receivedWO.ProdLineItemNum, ctes.receivedWO.OrderInformation.Customer, ctes.receivedWO.ComponentSet.Split(",")(1), GetGanadero(ctes.receivedWO.Notes), GetDelegacion(ctes.receivedWO.OrderInformation.Address))

        'btlabel.Printer = cmbImpresora.Text
        'btlabel.PrintOut(False, False)
        'If ctes.Tipo = "ITACA" Then
        '    btlabel.SetNamedSubStringValue("numPedido", ctes.receivedWO.ProdLineItemNum & "-H")
        '    btlabel.PrintOut(False, False)
        'Else
        '    'SI EL PEDIDO NO ES DE ITACA CERRAMOS LA LINEA DE PEDIDO CUANDO SE SACAN LAS PEGATINAS
        '    miRest.toProducedPost()
        '    'SI EL PEDIDO ES DE STOCK DM ADEMAS MARCAMOS EL PEDIDO COMO REVISADO
        '    'If ctes.Tipo = "SK" Then
        '    '    Marcar_Revisado()
        '    'End If
        'End If
        If ctes.Tipo = "ITACA" Then
            Imprimir_Etiqueta_Interna(True, False)
            Imprimir_Etiqueta_Interna(False, True)
        Else
            Imprimir_Etiqueta_Interna(False, False)
        End If

        miRest.Liberar()

    End Sub

    'IMPRESION CON DATAMARS LABEL
    Private Sub Imprimir_Etiqueta_Interna(ByVal macho As Boolean, ByVal hembra As Boolean)

        Dim m_DataTable As New DataTable
        Dim printerVarNames(5) As String
        Dim printerVars(5) As String
        printerVarNames(0) = "Var01"    'NumPedido
        printerVarNames(1) = "Var02"    'Cliente
        printerVarNames(2) = "Var03"    'Delegación
        printerVarNames(3) = "Var04"    'Ganadero
        printerVarNames(4) = "Var05"    'Producto
        printerVarNames(5) = "Var06"    'Fecha

        For i = 0 To printerVarNames.Length - 1
            m_DataTable.Columns.Add(printerVarNames(i))
        Next

        Dim etiquetas As New LabelPrinting()
        etiquetas.OpenLabel("C:\Labels\DMESP_Etiqueta_Interna.blf")
        etiquetas.PageSetup.PrinterName = cmbImpresora.Text
        etiquetas.LicenseKey = "71P49Q8100W26Q168Y60"

        etiquetas.DataSource = m_DataTable
        If IsNothing(ctes.receivedWO) Then
            If macho Then
                printerVars(0) = lb_pedido.Text & "-M"
            End If
            If hembra Then
                printerVars(0) = lb_pedido.Text & "-H"
            End If
            If Not macho And Not hembra Then
                printerVars(0) = lb_pedido.Text
            End If
            printerVars(1) = lb_cliente.Text
            printerVars(2) = lb_delegacion.Text
            printerVars(3) = lb_ganadero.Text
            printerVars(4) = lb_producto.Text
            printerVars(5) = Now.Date
        Else
            If macho Then
                printerVars(0) = ctes.receivedWO.ProdLineItemNum & "-M"
            End If
            If hembra Then
                printerVars(0) = ctes.receivedWO.ProdLineItemNum & "-H"
            End If
            If Not macho And Not hembra Then
                printerVars(0) = ctes.receivedWO.ProdLineItemNum
            End If
            printerVars(1) = ctes.receivedWO.OrderInformation.Customer
            printerVars(2) = GetDelegacion(ctes.receivedWO.OrderInformation.Address)
            printerVars(3) = GetGanadero(ctes.receivedWO.Notes)
            printerVars(4) = ctes.receivedWO.ComponentSet.Split(",")(1)
            printerVars(5) = Now.Date
        End If

        Dim row As DataRow = m_DataTable.NewRow
        For j = 0 To 5
            row(printerVarNames(j)) = printerVars(j)
        Next
        m_DataTable.Rows.Add(row)
        etiquetas.PrintOut(False)
        m_DataTable.Clear()

    End Sub

    Private Sub btn_imprimir_Click(sender As Object, e As EventArgs) Handles btn_imprimir.Click

        'Dim btlabel As BarTender.Format = btApp.Formats.Open(My.Application.Info.DirectoryPath & "\Etiqueta_ITACA.btw")
        'If ctes.Tipo = "ITACA" Then
        '    btlabel.SetNamedSubStringValue("numPedido", lb_pedido.Text & "-M")
        'Else
        '    btlabel.SetNamedSubStringValue("numPedido", lb_pedido.Text)
        'End If
        'If ctes.Tipo = "LECTORES" Then
        '    btlabel.SetNamedSubStringValue("producto", lb_producto.Text)
        '    btlabel.SetNamedSubStringValue("nombreDelegacion", lb_delegacion.Text)
        '    btlabel.SetNamedSubStringValue("fecha", Now.Date)
        'Else
        '    btlabel.SetNamedSubStringValue("nombreCliente", lb_cliente.Text)
        '    btlabel.SetNamedSubStringValue("producto", lb_producto.Text)
        '    btlabel.SetNamedSubStringValue("nombreGanadero", lb_ganadero.Text)
        '    btlabel.SetNamedSubStringValue("nombreDelegacion", lb_delegacion.Text)
        '    btlabel.SetNamedSubStringValue("fecha", Now.Date)
        'End If

        ''IMPRIMIMOS LA ETIQUETA DE LOS MACHOS
        'btlabel.Printer = cmbImpresora.Text
        'btlabel.PrintOut(False, False)
        'If ctes.Tipo = "ITACA" Then
        '    'IMPRIMIMOS LA ETIQUETA DE LAS HEMBRAS
        '    btlabel.SetNamedSubStringValue("numPedido", lb_pedido.Text & "-H")
        '    btlabel.PrintOut(False, False)
        'End If

        If ctes.Tipo = "ITACA" Then
            Imprimir_Etiqueta_Interna(True, False)
            Imprimir_Etiqueta_Interna(False, True)
        Else
            Imprimir_Etiqueta_Interna(False, False)
        End If

    End Sub

    Private Sub Cargar_datos_pedido(ByVal pedido As String, ByVal cliente As String, ByVal producto As String, ByVal ganadero As String, ByVal delegacion As String)

        CheckForIllegalCrossThreadCalls = False
        lb_pedido.Text = pedido
        lb_cliente.Text = cliente
        lb_producto.Text = producto
        lb_ganadero.Text = ganadero
        lb_delegacion.Text = delegacion

    End Sub

    Private Sub lbl_impresora_DropDownOpening(sender As Object, e As EventArgs) Handles cmbImpresora.DropDownOpening

        Dim pkInstalledPrinters As String
        For i As Integer = cmbImpresora.DropDownItems.Count - 1 To 0 Step -1
            RemoveHandler cmbImpresora.DropDownItems(i).Click, AddressOf ImpresorasMenuItem_Click
            cmbImpresora.DropDownItems.RemoveAt(i)
        Next

        cmbImpresora.DropDownItems.Clear()

        'Find all printers installed
        For Each pkInstalledPrinters In Drawing.Printing.PrinterSettings.InstalledPrinters
            cmbImpresora.DropDownItems.Add(pkInstalledPrinters)
            AddHandler cmbImpresora.DropDownItems(cmbImpresora.DropDownItems.Count - 1).Click, AddressOf ImpresorasMenuItem_Click
        Next pkInstalledPrinters

    End Sub

    Private Sub ImpresorasMenuItem_Click(sender As Object, e As EventArgs)

        Dim obj As ToolStripDropDownItem = sender
        cmbImpresora.Text = obj.Text
        INIWrite(My.Application.Info.DirectoryPath & "\settings.ini", "Impresora", "Impresora", cmbImpresora.Text)

    End Sub

    Public Sub Crear_Token()

        System.Net.ServicePointManager.SecurityProtocol = Net.SecurityProtocolType.Tls12
        Dim client As New RestClient("https://login.microsoftonline.com/5d7ef17f-affc-45f4-a3ce-3379dfb2c5ef/oauth2/token")
        Dim request As New RestRequest(Method.POST)
        request.AddHeader("Content-Type", "application/x-www-form-urlencoded")
        request.AddHeader("Cache-Control", "no-cache")
        'LIVE OS
        request.AddParameter("undefined", "grant_type=client_credentials&client_id=4ca5738a-a27a-4052-b833-50a77e3606fe&client_secret=1vwHhm3Roqua4Z1RgpOoPs1mHOegUpbp3BR0SXwPOsc=&resource=https%3A%2F%2Fgraph.windows.net%2F", ParameterType.RequestBody)

        Dim response As IRestResponse = client.Execute(request)
        ctes.access_token = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Token)(response.Content)
        INIWrite(My.Application.Info.DirectoryPath & "\settings.ini", "Config", "token", ctes.access_token.access_token)

    End Sub

    Private Sub GetOrderPS(ByVal pedido As String)

        Dim client As RestClient

        If IP_Local.StartsWith("10") Then
            client = New RestClient("http://10.45.1.2:11001/production/v1/production_items?number=" & pedido & "")
        Else
            client = New RestClient("http://192.168.14.13:11001/production/v1/production_items?number=" & pedido & "")
        End If
        Dim request = New RestRequest(Method.GET)
        request.AddHeader("Authorization", "Bearer " & ctes.access_token.access_token & "")
        Dim response As IRestResponse = client.Execute(request)

        Dim PS As New OrderPS

        PS = Newtonsoft.Json.JsonConvert.DeserializeObject(Of OrderPS)(response.Content)
        lb_cliente.Text = PS.content(0).production_order.bp_name
        lb_pedido.Text = PS.content(0).number
        lb_producto.Text = PS.content(0).component_set.name
        lb_delegacion.Text = PS.content(0).production_order.original_delivery_address.address_name
        lb_ganadero.Text = GetGanadero(PS.content(0).note)
        If PS.content(0).tag_printing_schema_instance.name.Contains("ITACA") Then
            ctes.Tipo = "ITACA"
        Else
            ctes.Tipo = "MANEJO"
        End If

    End Sub


    Private Sub txt_OrderPS_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_OrderPS.KeyDown

        If e.KeyData = Keys.KeyCode.Enter Then
            If ctes.Equipo.ToUpper.Contains("LECTORES") Then
                ctes.Tipo = "LECTORES"
            End If
            Cursor = Cursors.WaitCursor
            Crear_Token()
            GetOrderPS(txt_OrderPS.Text)
            Cursor = Cursors.Default
            btn_imprimir.Enabled = True
        End If

    End Sub

    Private Function GetDelegacion(ByVal Address As String) As String

        Try
            Dim delegacion() As String = Address.Split("|")
            Return delegacion(0)
        Catch ex As Exception
            Return ""
        End Try

    End Function

    Private Function GetGanadero(ByVal nota As String) As String

        Try
            Dim notas() As String = nota.Split(vbLf)
            Dim ganadero As String = ""
            For Each s As String In notas
                If s.StartsWith("U_ENDCUSTOMER:") Then
                    ganadero = s.Replace("U_ENDCUSTOMER: ", "")
                End If
            Next
            Return ganadero
        Catch ex As Exception
            Return ""
        End Try


    End Function

    Private Sub Marcar_Revisado()

        Dim revisado As New Pedidos_OSTableAdapters.RevisionesTableAdapter
        revisado.Insert(lb_pedido.Text, Now, ctes.Equipo)

    End Sub
End Class
