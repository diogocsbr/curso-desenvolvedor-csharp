﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventosProblemasQueOcorrem
{

    //Eventos dos controles

    //Erros

    //Gerando evento no Designer


    public partial class Form1 : Form
    {
        ClasseQueVaiSerLido classeQueVai;

        public Form1()
        {
            InitializeComponent();


            classeQueVai = new ClasseQueVaiSerLido();

            //Registrando o evento
            classeQueVai.EventoOcorreu += ClasseQueVai_EventoOcorreu;
        }

        private void ClasseQueVai_EventoOcorreu(object sender, ClasseEventArgs e)
        {
            MessageBox.Show($"O nome {e.Nome} foi adicionado");
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            classeQueVai.AdicionarNomes(txtNome.Text); 
        }
    }

    class ClasseQueVaiSerLido 
    {
        public event EventHandler<ClasseEventArgs> EventoOcorreu;

        protected virtual void OnEventoOcorreu(ClasseEventArgs args)
        {
            if (EventoOcorreu != null) EventoOcorreu(this, args);
        }

        public List<string> ListaNomes
        {
            get;set;
        } = new List<string>();

        public void AdicionarNomes(string nome)
        {
            this.ListaNomes.Add(nome);
            OnEventoOcorreu(new ClasseEventArgs(nome));
        }


    }

    public class ClasseEventArgs
    {
        public string Nome;

        public ClasseEventArgs(string nome)
        {
            Nome = nome;
        }
    }
}
