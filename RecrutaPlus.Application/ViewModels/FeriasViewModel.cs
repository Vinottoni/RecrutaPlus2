﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AutoMapper.Configuration.Annotations;
using RecrutaPlus.Domain.ValueObjects;
using System.ComponentModel;

namespace RecrutaPlus.Application.ViewModels
{
    public class FeriasViewModel
    {
        [Display(Name = "Código")]
        public int FeriasId { get; set; }
        public int FuncionarioId { get; set; }

        [Display(Name = "Valor Hora Extra")]
        public decimal ValorHoraExtra { get; set; }
        [Display(Name = "Dependentes")]
        public int Dependentes { get; set; }
        [Display(Name = "Dias de Férias")]
        public int DiasFerias { get; set; }
        [Display(Name = "Abono Pecuniário")]
        public bool AbonoPecuniario { get; set; }
        [Display(Name = "Décimo Terceiro")]
        public bool DecimoTerceiro { get; set; }
        

        //Default
        public DateTime Cadastro { get; set; }
        public string CadastradoPor { get; set; }
        public DateTime Edicao { get; set; }
        public string EditadoPor { get; set; }
        public long VersionStamp { get; set; } //public byte[]? VersionStamp { get; set; }
        public Guid GuidStamp { get; set; }

    }
}
