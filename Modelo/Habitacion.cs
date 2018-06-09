﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaHotel.Modelo
{
    public class Habitacion
    {
        private int idHabitacion = 0;
        private TipoHabitacion tipoHabitacion = null;
        private Boolean activa = false;
        private int numero = 0;
        private int piso = 0;
        private String ubicacion = "";
        private int idHotel;

        public Habitacion(int idHabitacion, TipoHabitacion tipoHabitacion,
            Boolean activa, int numero, int piso, String ubicacion,int idHotel)
        {
            this.idHabitacion = idHabitacion;
            this.tipoHabitacion = tipoHabitacion;
            this.activa = activa;
            this.numero = numero;
            this.piso = piso;
            this.ubicacion = ubicacion;
            this.idHotel = idHotel;
        }

        public int getIdHabitacion()
        {
            return idHabitacion;
        }

        public TipoHabitacion getTipoHabitacion()
        {
            return tipoHabitacion;
        }

        public Boolean getActiva()
        {
            return activa;
        }

        public int getNumero()
        {
            return numero;
        }

        public int getPiso()
        {
            return piso;
        }

        public String getUbicacion()
        {
            return ubicacion;
        }

        //Estos metodos extra los necesito para popular los combo box y data grid view
       
        public TipoHabitacion TipoHabitacion { get { return this.getTipoHabitacion(); } }
        public Boolean Activa { get { return this.getActiva(); } }
        public int Numero { get { return this.getNumero(); } }
        public int Piso { get { return this.getPiso(); } }
        public String Ubicacion { get { return this.getUbicacion(); } }

        public int IdHotel { get => idHotel; set => idHotel = value; }
        public int IdHabitacion { get => idHabitacion; set => idHabitacion = value; }
    }
}
