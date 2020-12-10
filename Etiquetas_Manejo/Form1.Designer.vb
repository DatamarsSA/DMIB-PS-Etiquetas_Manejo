<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.StatusStrip2 = New System.Windows.Forms.StatusStrip()
        Me.lblPSStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmbImpresora = New System.Windows.Forms.ToolStripDropDownButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lb_pedido = New System.Windows.Forms.Label()
        Me.lb_delegacion = New System.Windows.Forms.Label()
        Me.lb_producto = New System.Windows.Forms.Label()
        Me.btn_imprimir = New System.Windows.Forms.Button()
        Me.txt_OrderPS = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lb_ganadero = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lb_cliente = New System.Windows.Forms.Label()
        Me.StatusStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblPSStatus, Me.cmbImpresora})
        Me.StatusStrip2.Location = New System.Drawing.Point(0, 196)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStrip2.Size = New System.Drawing.Size(460, 22)
        Me.StatusStrip2.TabIndex = 1
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'lblPSStatus
        '
        Me.lblPSStatus.Name = "lblPSStatus"
        Me.lblPSStatus.Size = New System.Drawing.Size(119, 17)
        Me.lblPSStatus.Text = "ToolStripStatusLabel1"
        '
        'cmbImpresora
        '
        Me.cmbImpresora.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.cmbImpresora.Image = CType(resources.GetObject("cmbImpresora.Image"), System.Drawing.Image)
        Me.cmbImpresora.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.cmbImpresora.Name = "cmbImpresora"
        Me.cmbImpresora.Size = New System.Drawing.Size(165, 20)
        Me.cmbImpresora.Text = "ToolStripDropDownButton1"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 19)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Pedido"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 67)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 19)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Delegación"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 125)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 19)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Producto"
        '
        'lb_pedido
        '
        Me.lb_pedido.AutoSize = True
        Me.lb_pedido.Location = New System.Drawing.Point(103, 9)
        Me.lb_pedido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_pedido.Name = "lb_pedido"
        Me.lb_pedido.Size = New System.Drawing.Size(14, 19)
        Me.lb_pedido.TabIndex = 5
        Me.lb_pedido.Text = "-"
        '
        'lb_delegacion
        '
        Me.lb_delegacion.AutoSize = True
        Me.lb_delegacion.Location = New System.Drawing.Point(103, 67)
        Me.lb_delegacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_delegacion.Name = "lb_delegacion"
        Me.lb_delegacion.Size = New System.Drawing.Size(14, 19)
        Me.lb_delegacion.TabIndex = 6
        Me.lb_delegacion.Text = "-"
        '
        'lb_producto
        '
        Me.lb_producto.AutoSize = True
        Me.lb_producto.Location = New System.Drawing.Point(103, 125)
        Me.lb_producto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_producto.Name = "lb_producto"
        Me.lb_producto.Size = New System.Drawing.Size(14, 19)
        Me.lb_producto.TabIndex = 7
        Me.lb_producto.Text = "-"
        '
        'btn_imprimir
        '
        Me.btn_imprimir.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btn_imprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_imprimir.Location = New System.Drawing.Point(283, 157)
        Me.btn_imprimir.Name = "btn_imprimir"
        Me.btn_imprimir.Size = New System.Drawing.Size(165, 36)
        Me.btn_imprimir.TabIndex = 8
        Me.btn_imprimir.Text = "Reimprimir etiquetas"
        Me.btn_imprimir.UseVisualStyleBackColor = False
        '
        'txt_OrderPS
        '
        Me.txt_OrderPS.Location = New System.Drawing.Point(12, 163)
        Me.txt_OrderPS.Name = "txt_OrderPS"
        Me.txt_OrderPS.Size = New System.Drawing.Size(265, 27)
        Me.txt_OrderPS.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 96)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 19)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Ganadero"
        '
        'lb_ganadero
        '
        Me.lb_ganadero.AutoSize = True
        Me.lb_ganadero.Location = New System.Drawing.Point(103, 96)
        Me.lb_ganadero.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_ganadero.Name = "lb_ganadero"
        Me.lb_ganadero.Size = New System.Drawing.Size(14, 19)
        Me.lb_ganadero.TabIndex = 11
        Me.lb_ganadero.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 38)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 19)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Cliente"
        '
        'lb_cliente
        '
        Me.lb_cliente.AutoSize = True
        Me.lb_cliente.Location = New System.Drawing.Point(103, 38)
        Me.lb_cliente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lb_cliente.Name = "lb_cliente"
        Me.lb_cliente.Size = New System.Drawing.Size(14, 19)
        Me.lb_cliente.TabIndex = 13
        Me.lb_cliente.Text = "-"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(460, 218)
        Me.Controls.Add(Me.lb_cliente)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lb_ganadero)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txt_OrderPS)
        Me.Controls.Add(Me.btn_imprimir)
        Me.Controls.Add(Me.lb_producto)
        Me.Controls.Add(Me.lb_delegacion)
        Me.Controls.Add(Me.lb_pedido)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "ETIQUETAS MANEJO"
        Me.StatusStrip2.ResumeLayout(False)
        Me.StatusStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents lblPSStatus As ToolStripStatusLabel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lb_pedido As Label
    Friend WithEvents lb_delegacion As Label
    Friend WithEvents lb_producto As Label
    Friend WithEvents btn_imprimir As Button
    Friend WithEvents cmbImpresora As ToolStripDropDownButton
    Friend WithEvents txt_OrderPS As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents lb_ganadero As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lb_cliente As Label
End Class
