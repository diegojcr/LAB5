using System.ComponentModel.DataAnnotations;

namespace LAB5.Models
{
	public class Carros
	{
		[Display(Name = "Placa")]
		[Required(AllowEmptyStrings = false, ErrorMessage = "Debe de ingresar la placa del vehículo")]
		[RegularExpression(@"\d{6}", ErrorMessage = "La placa debe de contener 6 digitos")]
		public string placa { get; set; }

        [Display(Name = "Color")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe de ingresar el color del vehículo")]
        public string color { get; set; }

        [Display(Name = "Propietario")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe de ingresar el propietario del vehículo")]
        public string propiertario { get; set; } 

        [Display(Name = "Latitud")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe de ingresar la latitud del vehículo")]
        [Range(-90,90, ErrorMessage = "La latitud debe estar entre -90 y 90")]
        public string latitud { get; set; }

        [Display(Name = "Longitud")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Debe de ingresar la longitud del vehículo")]
        [Range(-180, 180, ErrorMessage = "La longitud debe estar entre -180 y 180")]

        public string longitud { get; set; }

		
	}
}
