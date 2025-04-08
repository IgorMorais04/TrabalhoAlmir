using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TrabalhoAlmir.Model {
    [Table("veiculos")]
    public class Veiculos {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; private set; }

        [Required]
        [StringLength(10)]
        public string placa { get; set; }

        [Required]
        [StringLength(50)]
        public string modelo { get; set; }

        [Required]
        [StringLength(50)]
        public string marca { get; set; }

        [Required]
        [Range(1900, 2100)] // Ano válido
        public int ano { get; set; }

        [Required]
        [StringLength(30)]
        public string cor { get; set; }

        //construtor
        public Veiculos(int id, string placa, string modelo, string marca, int ano, string cor) {


            this.id = id;
            this.placa = placa;
            this.modelo = modelo;
            this.marca = marca;
            this.ano = ano;
            this.cor = cor;
        }

        public Veiculos() {
        }
    }
}