﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Liga_Tabajara_Futebol.Models
{
	public enum Cargo
    {
        Treinador,
        PreparadorFisico,
        Massagista,
        Medico,
        AnalistaDeDesempenho,
        TreinadorDeGoleiros,
        Fisioterapeuta,
        Auxiliar
    }

    public class ComissaoTecnica
	{
        public int Id { get; set; }
        public string Nome { get; set; }
        public Cargo Cargo { get; set; }
        public DateTime DataNascimento { get; set; }
        public Time Time { get; set; }
    }
}