using System;
using System.ComponentModel.DataAnnotations;

namespace LojaDoSeuManoel.Dtos;

public class DimensaoDto
    {
        [Range(0.1, double.MaxValue, ErrorMessage = "A altura deve ser maior que zero.")]
        public decimal Altura { get; set; }
         [Range(0.1, double.MaxValue, ErrorMessage = "A largura deve ser maior que zero.")]
        public decimal Largura { get; set; }
         [Range(0.1, double.MaxValue, ErrorMessage = "A comprimento deve ser maior que zero.")]
        public decimal Comprimento { get; set; }
    }
