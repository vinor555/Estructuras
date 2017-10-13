namespace Proyecto2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.graficasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arbolBDestinosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiarWSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.limpiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarReservacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tHReservacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarRutasVueloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arbolBDestMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arbolBOrigMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.generarMatrizToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarABDestinosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarABDestMatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarABOrigMatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generarTHRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.generarGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivosToolStripMenuItem,
            this.graficasToolStripMenuItem,
            this.limpiarWSToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(600, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivosToolStripMenuItem
            // 
            this.archivosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarToolStripMenuItem,
            this.cargarReservacionesToolStripMenuItem,
            this.cargarRutasVueloToolStripMenuItem});
            this.archivosToolStripMenuItem.Name = "archivosToolStripMenuItem";
            this.archivosToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.archivosToolStripMenuItem.Text = "Archivos";
            // 
            // cargarToolStripMenuItem
            // 
            this.cargarToolStripMenuItem.Name = "cargarToolStripMenuItem";
            this.cargarToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cargarToolStripMenuItem.Text = "Cargar Destinos";
            this.cargarToolStripMenuItem.Click += new System.EventHandler(this.cargarToolStripMenuItem_Click);
            // 
            // graficasToolStripMenuItem
            // 
            this.graficasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.arbolBDestinosToolStripMenuItem,
            this.matrizToolStripMenuItem,
            this.tHReservacionesToolStripMenuItem,
            this.arbolBDestMToolStripMenuItem,
            this.arbolBOrigMToolStripMenuItem,
            this.generarMatrizToolStripMenuItem,
            this.generarABDestinosToolStripMenuItem,
            this.generarABDestMatToolStripMenuItem,
            this.generarABOrigMatToolStripMenuItem,
            this.generarTHRToolStripMenuItem,
            this.generarGrafoToolStripMenuItem});
            this.graficasToolStripMenuItem.Name = "graficasToolStripMenuItem";
            this.graficasToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.graficasToolStripMenuItem.Text = "Graficas";
            // 
            // arbolBDestinosToolStripMenuItem
            // 
            this.arbolBDestinosToolStripMenuItem.Name = "arbolBDestinosToolStripMenuItem";
            this.arbolBDestinosToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.arbolBDestinosToolStripMenuItem.Text = "ArbolB Destinos";
            this.arbolBDestinosToolStripMenuItem.Click += new System.EventHandler(this.arbolBDestinosToolStripMenuItem_Click);
            // 
            // matrizToolStripMenuItem
            // 
            this.matrizToolStripMenuItem.Name = "matrizToolStripMenuItem";
            this.matrizToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.matrizToolStripMenuItem.Text = "Matriz ";
            this.matrizToolStripMenuItem.Click += new System.EventHandler(this.matrizToolStripMenuItem_Click);
            // 
            // limpiarWSToolStripMenuItem
            // 
            this.limpiarWSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.limpiarToolStripMenuItem});
            this.limpiarWSToolStripMenuItem.Name = "limpiarWSToolStripMenuItem";
            this.limpiarWSToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.limpiarWSToolStripMenuItem.Text = "LimpiarWS";
            // 
            // limpiarToolStripMenuItem
            // 
            this.limpiarToolStripMenuItem.Name = "limpiarToolStripMenuItem";
            this.limpiarToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.limpiarToolStripMenuItem.Text = "Limpiar";
            this.limpiarToolStripMenuItem.Click += new System.EventHandler(this.limpiarToolStripMenuItem_Click);
            // 
            // cargarReservacionesToolStripMenuItem
            // 
            this.cargarReservacionesToolStripMenuItem.Name = "cargarReservacionesToolStripMenuItem";
            this.cargarReservacionesToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cargarReservacionesToolStripMenuItem.Text = "Cargar Reservaciones";
            this.cargarReservacionesToolStripMenuItem.Click += new System.EventHandler(this.cargarReservacionesToolStripMenuItem_Click);
            // 
            // tHReservacionesToolStripMenuItem
            // 
            this.tHReservacionesToolStripMenuItem.Name = "tHReservacionesToolStripMenuItem";
            this.tHReservacionesToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.tHReservacionesToolStripMenuItem.Text = "THReservaciones";
            this.tHReservacionesToolStripMenuItem.Click += new System.EventHandler(this.tHReservacionesToolStripMenuItem_Click);
            // 
            // cargarRutasVueloToolStripMenuItem
            // 
            this.cargarRutasVueloToolStripMenuItem.Name = "cargarRutasVueloToolStripMenuItem";
            this.cargarRutasVueloToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.cargarRutasVueloToolStripMenuItem.Text = "Cargar Rutas Vuelo";
            this.cargarRutasVueloToolStripMenuItem.Click += new System.EventHandler(this.cargarRutasVueloToolStripMenuItem_Click);
            // 
            // arbolBDestMToolStripMenuItem
            // 
            this.arbolBDestMToolStripMenuItem.Name = "arbolBDestMToolStripMenuItem";
            this.arbolBDestMToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.arbolBDestMToolStripMenuItem.Text = "ArbolB DestM";
            this.arbolBDestMToolStripMenuItem.Click += new System.EventHandler(this.arbolBDestMToolStripMenuItem_Click);
            // 
            // arbolBOrigMToolStripMenuItem
            // 
            this.arbolBOrigMToolStripMenuItem.Name = "arbolBOrigMToolStripMenuItem";
            this.arbolBOrigMToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.arbolBOrigMToolStripMenuItem.Text = "ArbolB OrigM";
            this.arbolBOrigMToolStripMenuItem.Click += new System.EventHandler(this.arbolBOrigMToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(8, 78);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(108, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "RUTAS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Origen";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(168, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Destino";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(134, 78);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(102, 21);
            this.comboBox2.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 154);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Modificar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(254, 114);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Crear";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(254, 34);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "LlenarCB";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(254, 76);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "Eliminar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // generarMatrizToolStripMenuItem
            // 
            this.generarMatrizToolStripMenuItem.Name = "generarMatrizToolStripMenuItem";
            this.generarMatrizToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.generarMatrizToolStripMenuItem.Text = "Generar matriz";
            this.generarMatrizToolStripMenuItem.Click += new System.EventHandler(this.generarMatrizToolStripMenuItem_Click);
            // 
            // generarABDestinosToolStripMenuItem
            // 
            this.generarABDestinosToolStripMenuItem.Name = "generarABDestinosToolStripMenuItem";
            this.generarABDestinosToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.generarABDestinosToolStripMenuItem.Text = "Generar AB Destinos";
            this.generarABDestinosToolStripMenuItem.Click += new System.EventHandler(this.generarABDestinosToolStripMenuItem_Click);
            // 
            // generarABDestMatToolStripMenuItem
            // 
            this.generarABDestMatToolStripMenuItem.Name = "generarABDestMatToolStripMenuItem";
            this.generarABDestMatToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.generarABDestMatToolStripMenuItem.Text = "Generar AB DestMat";
            this.generarABDestMatToolStripMenuItem.Click += new System.EventHandler(this.generarABDestMatToolStripMenuItem_Click);
            // 
            // generarABOrigMatToolStripMenuItem
            // 
            this.generarABOrigMatToolStripMenuItem.Name = "generarABOrigMatToolStripMenuItem";
            this.generarABOrigMatToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.generarABOrigMatToolStripMenuItem.Text = "Generar AB OrigMat";
            this.generarABOrigMatToolStripMenuItem.Click += new System.EventHandler(this.generarABOrigMatToolStripMenuItem_Click);
            // 
            // generarTHRToolStripMenuItem
            // 
            this.generarTHRToolStripMenuItem.Name = "generarTHRToolStripMenuItem";
            this.generarTHRToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.generarTHRToolStripMenuItem.Text = "Generar THR";
            this.generarTHRToolStripMenuItem.Click += new System.EventHandler(this.generarTHRToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Costo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tiempo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 130);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 12;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(136, 130);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 13;
            // 
            // generarGrafoToolStripMenuItem
            // 
            this.generarGrafoToolStripMenuItem.Name = "generarGrafoToolStripMenuItem";
            this.generarGrafoToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.generarGrafoToolStripMenuItem.Text = "Generar Grafo";
            this.generarGrafoToolStripMenuItem.Click += new System.EventHandler(this.generarGrafoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 327);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem graficasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arbolBDestinosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem limpiarWSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem limpiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarReservacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tHReservacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarRutasVueloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arbolBDestMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arbolBOrigMToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ToolStripMenuItem generarMatrizToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarABDestinosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarABDestMatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarABOrigMatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generarTHRToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ToolStripMenuItem generarGrafoToolStripMenuItem;
    }
}

