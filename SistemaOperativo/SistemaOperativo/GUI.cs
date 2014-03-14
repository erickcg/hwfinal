﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaOperativo
{
    public partial class GUI : Form
    {
         static String path = "C://Users//maesther//Desktop//hwfinal-master//SistemaOperativo//proc.txt";
            pcb procesos = SetProcesos(path);
        public GUI()
        {
            InitializeComponent();

            
            DataTable table = new DataTable();
            table.Columns.Add("Pagina", Type.GetType("System.String"));
            table.Columns.Add("R", Type.GetType("System.String"));
            table.Columns.Add("Llegada", Type.GetType("System.String"));
            table.Columns.Add("Ultimo acceso", Type.GetType("System.String"));
            table.Columns.Add("Acceso", Type.GetType("System.String"));
            table.Columns.Add("NURlectura", Type.GetType("System.String"));
            table.Columns.Add("Modificacion", Type.GetType("System.String"));
         

            
            
          //  String path = "C://Users//maesther//Desktop//hwfinal-master//SistemaOperativo//proc.txt";
          //   procesos = SetProcesos(path);
            procesos.showState();
        
            Console.WriteLine("\n---------------------------------------------------------");
            procesos.LFU(3, 3);
            procesos.showState();
            tbTiempoA.Text = procesos.getTiempo().ToString();



            tbNombre.Text = procesos.getProcesoByID(procesos.getRunningProccess()).getId().ToString();
            tbLlegada.Text = procesos.getProcesoByID(procesos.getRunningProccess()).getLlegada().ToString();
            //tbCpuAsignado.Text= procesos.getProcesoByID(procesos.getRunningProccess())
           // tbEnvejecimiento
            //tbQuantumRestante.Text=
        Pagina auxpaginacion = procesos.getProcesoByID(procesos.getRunningProccess()).getListaPagina().getPagina();
        while (auxpaginacion != null)
        {
            table.Rows.Add(auxpaginacion.getNumero(),
                auxpaginacion.getResidencia(),
                auxpaginacion.getLlegada(), 
                auxpaginacion.getAcceso(), 
                auxpaginacion.getNumAcceso(),
                auxpaginacion.getNURlectura(),
                auxpaginacion.getModificacion());
            cbPaginas.Items.Add(auxpaginacion.getNumero());
            auxpaginacion = auxpaginacion.getNextPagina();
        }
        cbAlgoritmos.Items.Add("FIFO");
        cbAlgoritmos.Items.Add("LFU");
        cbAlgoritmos.Items.Add("LRU");
        cbAlgoritmos.Items.Add("NUR");

        dataGridView1.DataSource = table;

           
        }
     

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
           
            
        }

        private static pcb SetProcesos(String path)
        {
            pcb procesos = new pcb();

            try
            {
                // Lectura del fichero
                string[] lines = System.IO.File.ReadAllLines(@path);
                String linea;
                int pointer = 0;
                String[] current;

                linea = lines[pointer].Trim();
                procesos.setMaxPag(int.Parse(linea));
                pointer++;

                linea = lines[pointer].Trim();
                procesos.setNumProcesos(int.Parse(linea));
                pointer++;

                int id, llegada, tiempo, estado, numpaginas;

                for (int numproc = 1; numproc <= procesos.getNumProcesos(); numproc++)
                {
                    linea = lines[pointer].Trim();
                    current = linea.Split(',');
                    id = numproc;
                    llegada = int.Parse(current[0].Trim());
                    tiempo = int.Parse(current[1].Trim());
                    estado = int.Parse(current[2].Trim());
                    pointer++;

                    linea = lines[pointer].Trim();
                    numpaginas = int.Parse(linea);
                    procesos.setProceso(id, llegada, tiempo, estado, numpaginas);
                    pointer++;

                    for (int numpag = 0; numpag <= procesos.getLastProceso().getNumeropaginas() - 1; numpag++)
                    {
                        linea = lines[pointer].Trim();
                        current = linea.Split(',');
                        procesos.getLastProceso().setPagina(numpag,
                                                            int.Parse(current[0].Trim()),
                                                            int.Parse(current[1].Trim()),
                                                            int.Parse(current[2].Trim()),
                                                            int.Parse(current[3].Trim()),
                                                            int.Parse(current[4].Trim()),
                                                            int.Parse(current[5].Trim()));
                        pointer++;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("\n<<<<<<<<<<<<<<<<<<<<<<<<<<<<<Error de archivo>>>>>>>>>>>>>>>>>>>>>>>>>>\n");
                e.ToString();
            }
            procesos.setTiempo();

            return procesos;
        }

        private void GUI_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void cbPaginas_SelectedIndexChanged(object sender, EventArgs e)
        {



        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bAlgoritmo_Click(object sender, EventArgs e)
        {
            string pagselect = cbPaginas.SelectedText;
            
            if (cbAlgoritmos.SelectedText   == "FIFO" )
            {

                
                procesos.FIFO(procesos.getProcesoByID(procesos.getRunningProccess()).getId() , Convert.ToInt32(pagselect));

            }
            if (cbAlgoritmos.SelectedText == "LFU")
            {
                
            }
            if (cbAlgoritmos.SelectedText == "LRU")
            {
                
            }
            if (cbAlgoritmos.SelectedText == "NUR")
            {
                
            }

        } // fin Setprocesos 
    }
}
