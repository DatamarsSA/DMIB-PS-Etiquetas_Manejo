
Public Class MyRestServer

    Dim restServer As DMServiceLibrary.WCFRestServer
    Dim orders As List(Of ProductionData.DMProductionOrder)
    Dim stxControl As New STXControl.STXControl

    Event receivedOrder()


    Sub New()

        restServer = New DMServiceLibrary.WCFRestServer

        'stxControl.setCredentials((String)Properties.Settings.Default["REST_Credentials"])
        stxControl.setCredentials("bm9ydGhlcm4uaXJlbGFuZDo5OGFzZDg5Z2d4cmV6MDkyNDIz")

        ' the function setCredential(username,password) can also be used
        'stxControl.setEnpointProduced((String)Properties.Settings.Default["REST_ProducedEndpoint"])
        'stxControl.setEnpointError((String)Properties.Settings.Default["REST_ErrorEndpoint"])
        'Me.stxControl.setOrderProduced(orderProduced)

        restServer.setNewOrderDataAvailableCallback(Sub() getProdData()) '// Paddy Sw legacy Interface
        restServer.setNewFSOrderDataAvailableCallback(Sub() FSgetProdData()) ' // Finishing Sw Interface
        'restServer.setOrderCancellationCallback(Sub() orderCancel())
        restServer.setFSOrderCancellationCallback(Sub() FSorderCancel())
    End Sub

    Sub getProdData()

    End Sub
    Sub openRestServer()
        Me.restServer.open()
    End Sub

    Sub FSgetProdData()

        Dim orders As List(Of ProductionData.FSProductionOrder) = Me.restServer.FSgetProductionOrders()

        If orders.Count = 1 Then

            ctes.receivedWO = orders(0)

            Dim carpeta As String = My.Application.Info.DirectoryPath & "\Pedidos recibidos\"

            If Not IO.Directory.Exists(carpeta) Then IO.Directory.CreateDirectory(carpeta)

            IO.File.WriteAllText(carpeta & ctes.receivedWO.ProdLineItemNum & ".json", Newtonsoft.Json.JsonConvert.SerializeObject(ctes.receivedWO))
            Select Case ctes.receivedWO.ProdItems(0).Lasers(0).LayoutName
                Case "DMESP_ITACA"
                    If ctes.Equipo.ToUpper.Contains("LASER") Then
                        ctes.Tipo = "ITACA"
                        RaiseEvent receivedOrder()
                    Else
                        MsgBox("Equipo no habilitado para pedidos de ITACA")
                    End If
                Case "DMESP_ITACA_SERIE"
                    If ctes.Equipo.ToUpper.Contains("LASER") Then
                        ctes.Tipo = "ITACA"
                        RaiseEvent receivedOrder()
                    Else
                        MsgBox("Equipo no habilitado para pedidos de ITACA")
                    End If
                Case "DMESP_ITACA_SIN_SERIE"
                    If ctes.Equipo.ToUpper.Contains("LASER") Then
                        ctes.Tipo = "ITACA"
                        RaiseEvent receivedOrder()
                    Else
                        MsgBox("Equipo no habilitado para pedidos de ITACA")
                    End If
                Case "DMESP_ITACA_SERIE_DOBLE"
                    If ctes.Equipo.ToUpper.Contains("LASER") Then
                        ctes.Tipo = "ITACA"
                        RaiseEvent receivedOrder()
                    Else
                        MsgBox("Equipo no habilitado para pedidos de ITACA")
                    End If
                Case "DMESP_LECTORES"
                    If ctes.Equipo.ToUpper.Contains("LECTORES") Then
                        ctes.Tipo = "LECTORES"
                        RaiseEvent receivedOrder()
                    Else
                        MsgBox("Equipo no habilitado para pedidos de LECTORES")
                    End If
                Case "DMESP_MANEJO"
                    If ctes.Equipo.ToUpper.Contains("LASER") Or ctes.Equipo.ToUpper.Contains("ALMACEN") Then
                        ctes.Tipo = "MANEJO"
                        RaiseEvent receivedOrder()
                    Else
                        MsgBox("Equipo no habilitado para pedidos de MANEJO")
                    End If
                Case "DMESP_ALMACEN"
                    If ctes.Equipo.ToUpper.Contains("ALMACEN") Then
                        ctes.Tipo = "ALMACEN"
                        RaiseEvent receivedOrder()
                    Else
                        MsgBox("Equipo no habilitado para pedidos de ALMACEN")
                    End If
                Case "DMESP_SK"
                    If ctes.Equipo.ToUpper.Contains("STOCK") Then
                        ctes.Tipo = "SK"
                        RaiseEvent receivedOrder()
                    Else
                        MsgBox("Equipo no habilitado para pedidos de STOCK DE SK")
                    End If
                Case Else
                    MsgBox("Error en pedido, esquema no válido o en blanco")
            End Select

        End If

    End Sub


    Sub FSorderCancel()
        'restServer.InProduction = False

    End Sub

    Public Sub Liberar()
        restServer.InProduction = False

    End Sub

    Public Sub toProducedPost()

        Dim order As New ProductionData.FSproducedOrder()

        order.ProdLineItemNum = ctes.receivedWO.ProdLineItemNum
        order.AssignmentID = ctes.receivedWO.AssignmentID
        'order.ProducedItems = New List(Of ProductionData.FSproducedItems)
        order.ItemType = "ISO_ANIMAL"
        order.User = "LID - Management"
        order.ProdMachine = My.Computer.Name


        Dim json As String = Newtonsoft.Json.JsonConvert.SerializeObject(order)
        Dim carpeta As String = My.Application.Info.DirectoryPath & "\Producidos\" & order.ProdLineItemNum

        If IO.Directory.Exists(carpeta) = False Then IO.Directory.CreateDirectory(carpeta)

        Dim archivo As String = carpeta & "\" & order.ProdLineItemNum & ".json"

        Dim j As Integer = 0

        If Not IO.Directory.Exists(carpeta) Then IO.Directory.CreateDirectory(carpeta)

        While IO.File.Exists(archivo)
            j += 1
            archivo = carpeta & "\" & order.ProdLineItemNum & " (" & j & ").json"
        End While

        IO.File.WriteAllText(archivo, json)

        'Dim client As New DMServiceLibrary.RestClient("http://192.168.14.13:11001/production/v1/produced_orders", DMServiceLibrary.RestClient.HttpVerb.POST, json)
        Dim client As New DMServiceLibrary.RestClient("http://10.45.1.2:11001/production/v1/produced_orders", DMServiceLibrary.RestClient.HttpVerb.POST, json)
        client.setCredentials("bm9ydGhlcm4uaXJlbGFuZDo5OGFzZDg5Z2d4cmV6MDkyNDIz")

        Try
            client.MakeRequest()
            'MessageBox.Show("Pedido cerrado correctamente!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            IO.File.WriteAllText(carpeta & "\Error " & Now.ToString("yyyy-MM-dd HHmmss") & ".txt", json)
            'MessageBox.Show(ex.Message, "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub



End Class
