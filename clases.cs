using System;

public class Clases
{

	public static void Registrar()
	{
		color_R();
		Console.WriteLine("ingresa los datos del motor :");
		color_R();
		Console.WriteLine("-----------------------------");
		var motoritas = new Motoritas();


		Console.Write("ingrese una cedula : ");
		var algo = "";


		algo = Console.ReadLine() ?? "";


		motoritas.Cedula = algo;












		var url = "https://api.adamix.net/apec/cedula/" + algo;


		System.Net.WebClient Algoo = new System.Net.WebClient();
		string Algo2 = Algoo.DownloadString(url);



		Root cedulacion = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(Algo2);



		if (cedulacion.ok != true)
		{
			color_R();
			Console.WriteLine("la cedula no esta registrada");
			color_R();
			Console.Write("ingrese nombre y apellido : ");
			motoritas.Nombre = Console.ReadLine() ?? "default";

        }
        else
        {
			motoritas.Nombre = $@"{cedulacion.Nombres} {cedulacion.Apellido1} {cedulacion.Apellido2}";
			Console.WriteLine("nombre ingresado de la cedula");
		}








		color_R();


		Console.Write("ingrese marca : ");
		motoritas.Marca = Console.ReadLine() ?? "default";
		color_R();

		Console.Write("ingrese modelo : ");
		motoritas.Modelo = Console.ReadLine() ?? "default";

		color_R();
		Console.Write("ingrese placa : ");
		motoritas.Placa = Console.ReadLine() ?? "default";

		color_R();
		Console.Write("ingrese chasis : ");
		motoritas.Chasis = Console.ReadLine() ?? "default";
		color_R();
		Console.Write("ingrese telefono : ");
		motoritas.Telefono = Console.ReadLine() ?? "default";

		color_R();
		Console.Write("ingrese direccion : ");
		motoritas.Direccion = Console.ReadLine() ?? "default";

		color_R();



		Console.Write("ingrese laptitud : ");
		float v_lap = 0;
		while (!float.TryParse(Console.ReadLine().Trim(), out v_lap))
		{
			Console.Write("la entra no es un numero , introdusca uno :");
		};

        while (v_lap > 20.06272397198361 || v_lap < 17.30657949464245)
        {
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("lo sentimos  el la laptitub que usted acaba de introducir sale de los limites del pais :");
			float.TryParse(Console.ReadLine().Trim(), out v_lap);


		};
		motoritas.Ing = v_lap.ToString();

		color_R();
		Console.Write("ingrese longitud : ");

		float v_ing = 0;
		while (!float.TryParse(Console.ReadLine().Trim(), out v_ing))
		{
			Console.Write("la entra no es un numero , introdusca uno :");
		};

		while (v_ing <  -72.02881418100763 || v_ing > -67.69776039797065)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.Write("lo sentimos  el la longitud que usted acaba de introducir sale de los limites del pais :");
			float.TryParse(Console.ReadLine(), out v_ing);


		};
		motoritas.Lat = v_ing.ToString();











		color_R();
		Console.Write("ingrese actividad : ");
		motoritas.Actividad = Console.ReadLine() ?? "default";

		color_R();
		Console.Write("ingrese descripccion : ");
		motoritas.Descripcion = Console.ReadLine() ?? "default";

		color_R();
		Lista.Guardar(motoritas);
		Console.WriteLine("motor agregado : ");


	}
	public static void Editar()
	{
		color_R();
		Console.WriteLine("editar motor");
		color_R();
		Console.WriteLine("-----------------------------");
		var motores = Lista.Listamotoritas();
        if (motores.Count == 0)
        {
			Console.Write("no hay motores ingresados : ");
			return;
		}


		Console.Write("motores ");
		foreach(var motor in motores)
        {
			color_R();
			Console.WriteLine(@$"

posicion : {motores.IndexOf(motor) + 1}
marca : {motor.Marca}
modelo : {motor.Modelo}
cedula : {motor.Cedula}
nombre : {motor.Nombre}


");
		};
		Console.Write("ingrese la opcion del motor que editara ");
		
		int posicion = 0;
		
        while (!int.TryParse(Console.ReadLine(), out posicion))
        {
			Console.Write("ingrese una opcion porfavor : ");

		}

		var motorEditar = motores[posicion - 1];
		int algo = 0;

		Console.Write($"ingrese cedula({motorEditar.Cedula}) :");

		var algoo = "";


		Console.Write($"ingrese una cedula valida({motorEditar.Cedula}) :");
		algoo = Console.ReadLine();
		motorEditar.Cedula = algoo;


		Console.Write($"ingrese nombre({motorEditar.Nombre}) : ");
		motorEditar.Nombre = Console.ReadLine() ?? "";
		color_R();
		Console.Write($"ingrese marca({motorEditar.Marca}) : ");
		motorEditar.Marca = Console.ReadLine() ?? "";
		color_R();
		Console.Write($"ingrese modelo({motorEditar.Modelo}) : ");
		motorEditar.Modelo = Console.ReadLine() ?? "";
		color_R();
		Console.Write($"ingrese placa({motorEditar.Placa}) : ");
		motorEditar.Placa = Console.ReadLine() ?? "";
		color_R();
		Console.Write($"ingrese chasis({motorEditar.Chasis}) : ");
		motorEditar.Chasis = Console.ReadLine() ?? "";
		color_R();
		Console.Write($"ingrese telefono({motorEditar.Telefono}) : ");
		motorEditar.Telefono = Console.ReadLine() ?? "";

		color_R();

		Console.Write($"ingrese direccion({motorEditar.Direccion}) :");
		motorEditar.Direccion = Console.ReadLine() ?? "";
		color_R();

		Console.Write($"ingrese laptitup({motorEditar.Lat}) : ");
		motorEditar.Lat = Console.ReadLine() ?? "";

		color_R();
		Console.Write($"ingrese longitud({motorEditar.Ing}) : ");
		motorEditar.Ing = Console.ReadLine() ?? "";
		color_R();

		Console.Write($"ingrese Actividad({motorEditar.Actividad}) : ");
		motorEditar.Actividad = Console.ReadLine() ?? "";

		color_R();
		Console.Write($"ingrese descripcion({motorEditar.Descripcion}) : ");
		motorEditar.Descripcion = Console.ReadLine() ?? "";

		Lista.Guardar(motorEditar);

		Console.WriteLine("datos modificado con exito");



	}


	public static void Mapa() {
		color_R();
		Console.WriteLine("Se presentara el mapa");

		var plantilla = "";
		var marcadores = "";
		var motores = Lista.Listamotoritas();


		foreach(var moto in motores)
        {
			marcadores += $@"
        var marker = L.marker([{moto.Ing}, {moto.Lat}]).addTo(map).bindPopup(`
        <h1>{moto.Nombre}</h1>
        <p> <strong>Marca :</strong> {moto.Marca} </p>
        <p><strong>Modelo:</strong> {moto.Modelo}</p>
        <p><strong>Placa:</strong> {moto.Placa} </p>
        <p><strong>uso:</strong> {moto.Actividad} </p>
`).openPopup();

";
        };




		plantilla = System.IO.File.ReadAllText("index.html");
		plantilla = plantilla.Replace("//MANANA ES LUNES", marcadores);
		System.IO.File.WriteAllText("mapas.html", plantilla);



		var uri = "mapas.html";
		var psi = new System.Diagnostics.ProcessStartInfo();
		psi.UseShellExecute = true;
		psi.FileName = uri;
		System.Diagnostics.Process.Start(psi);


		Console.WriteLine("salida con exito");


	}

	public static void Permiso()
	{



		var motores = Lista.Listamotoritas();
		color_R();
		Console.WriteLine("imprimir permiso");
		color_R();
		Console.WriteLine("-----------------------------");

		if (motores.Count == 0)
		{
			Console.Write("no hay motores ingresados");
			return;
		}


		Console.WriteLine("motores ");
		Console.WriteLine("----------------");
		var motoress = Lista.Listamotoritas();
		foreach (var motorr in motores)
		{
			color_R();
			Console.WriteLine(@$"

posicion : {motoress.IndexOf(motorr) + 1}
marca : {motorr.Marca}
modelo : {motorr.Modelo}
cedula : {motorr.Cedula}
nombre : {motorr.Nombre}

-----------------------------------------------


");


		}
		Console.Write("ingrese el usuario deseado :");
		int entrada = 0;
		int.TryParse(Console.ReadLine(), out entrada);





		var motor = motores[entrada-1];
		var img = "https://cdn.icon-icons.com/icons2/67/PNG/512/user_13230.png";


			var ccc = motor.Cedula;
		Console.WriteLine(ccc);


			var url = "https://api.adamix.net/apec/cedula/" + ccc;


			System.Net.WebClient Algo = new System.Net.WebClient();
			string Algo2 = Algo.DownloadString(url);



			Root cedulacion = Newtonsoft.Json.JsonConvert.DeserializeObject<Root>(Algo2);

		

		if (cedulacion.ok == true) {
			img = cedulacion.foto;

		}


















		string plantilla = "";
		plantilla = $@"


<!doctype html>
<html lang='en'>

<head>
    <meta charset='utf-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <title>permiso de {motor.Nombre}</title>
    <link href='https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/css/bootstrap.min.css' rel='stylesheet'
        integrity='sha384-0evHe/X+R7YkIZDRvuzKMRqM+OrBnVFBL6DOitfPri4tjfHxaWutUpFmBp4vmVor' crossorigin='anonymous'>

    <link rel='shortcut icon' href='https://cdn-icons-png.flaticon.com/512/2898/2898536.png' type='image/x-icon'>
</head>

<style>
    @import url('https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;1,100;1,300&display=swap');
    * {{
        margin: 0px;
        padding: 0px;

    }}

    .licencia {{
background: rgb(61,71,237);
background: linear-gradient(138deg, rgba(61,71,237,1) 0%, rgba(255,255,255,1) 40%, rgba(255,255,255,1) 59%, rgba(255,10,10,1) 100%);
        margin: auto;
        width: 65%;
        height: 550px;
        position: relative;
        top: 50px;
        border-radius: 30px;
padding: 10px;
        box-shadow: 4px 7px 16px 1px rgba(0, 0, 0, 0.35);
    }}


    .arriba_izquierda {{

        padding: 10px;
        color: #fff;
        text-shadow: -2px -2px 5px rgba(0, 50, 243, 1);
        display: flex;

    }}

    .arriba_centro {{
        justify-items: center;
        padding-top: 20px;
        color: #fff;
        text-shadow: -2px -2px 5px rgba(0, 50, 243, 1);
    }}

    .ldc {{
        background-color: blue;
        text-align: center;
        border-radius: 5px;
        color: #fff;
    }}

    .arriba_derecha {{
        margin: auto;


    }}

    .arriba_derecha img {{
        width: 110px;
        height: 110px;
        margin: auto;
        position: relative;
        left: 30%;
        bottom: 10px;
        border: 1px solid rgb(0, 0, 0);
        border-radius: 20px;
        padding: 8px;
    }}
.medio_izquierda{{
text-align:center;

}}
    .medio_izquierda img{{
padding: 5px;
    }}
    .medio_izquierda img{{
width: 100%;
height: auto;
margin: auto;
margin-bottom:5px ;

    }}
    .nombre{{
        border-bottom: 5px solid rgba(0, 0, 0, 0.452) ;
    }}

    .medio_derecha{{


    }}
            .medio_derecha img{{
margin: auto;
width: 100%;
position: relative;
right: 20%;
top: 20px;

    }}
        .medio_derecha .tt{{
margin: auto;
width: 60%;
height: auto;
opacity: 0.2;
position: relative;
left: 20%;
top: 5px;

    }}
    .direccion{{
        font-weight: 500;
        font-size: 20px;

        margin: auto;
        width: 200%;
        text-align: center;
        position: relative;
        right: 80%;
        top: 10px;
        color: #fff;
        text-shadow: -2px -2px 5px rgb(243, 0, 0);

    }}
.tabla{{
    width: 100%;
    margin:auto;
}}
.tabla *{{
    margin: 15px  0px  15px 0px;
}}
.ddd{{
    margin: 10px 0px 10px 0px;
}}
</style>

<body>

    <div class='licencia container'>
        <div class='row arriba'>

            <div class='col-3 arriba_izquierda'>
                <h3 style='text-align: center;'>ministerio <br /> de obra <br /> publicas y <br /> comunicaciones</h3>
            </div>

            <div class='col-6 arriba_centro'>
                <h1 style='text-align: center;'>REPUBLICA DOMINICANA</h1>
                <div class='ldc'>
                    <h5>LICENCIA DE CONDUCIR</h5>
                </div>


            </div>
            <div class='col-3 arriba_derecha '>
                <div class='escudo'>
                    <img src='https://1.bp.blogspot.com/__ocK0u_yh_A/TZjTZd3EDGI/AAAAAAAAJdI/4JeOducF2o4/s640/escudo_dominicano_para_colorear%5B2%5D.jpg'
                        alt=''>
                </div>


            </div>

        </div>
        <div class='row medio '>
<div class='col-3 medio_izquierda'>
<img src='{img}' alt=''>
<h1>{motor.Cedula}</h1>

</div>
<div class='col-7 medio_medio'>
<div class='nombre'>
<h1>{motor.Nombre}</h1>
</div>

<h5 class='ddd'>Direccion</h5>
<h4>{motor.Direccion}</h4>

<table class='tabla'>

    <tr>

        <td><h4>Marca</h4></td>


        <td><h4>Modelo</h4></td>

        <td><h4>chasis</h4></td>

    </tr>

    <tr>

        <td>{motor.Marca}</td>

        <td>{motor.Modelo}</td>

        <td>{motor.Chasis}</td>

    </tr>

</table>
<table class='tabla'>

    <tr>

        <td>
            <h4>placa</h4>
        </td>


        <td>
            <h4>actividad</h4>
        </td>


        <td>
            <h4>telefono</h4>
        </td>

    </tr>

    <tr>

        <td>{motor.Placa}</td>

        <td>{motor.Actividad}</td>

        <td>{motor.Telefono}</td>

    </tr>

</table>

</div>
<div class='col-2 medio_derecha'>

    <img class='tt' src='{img}' alt=''>
    <img src='https://upload.wikimedia.org/wikipedia/commons/a/af/Firma_Humberto_Gordon.png' alt=''>
<div class='direccion'><h3>direccion <br> general de <br> transito terrestre</h3></div>


</div>
        </div>
        <div class='row abajo '>

        </div>
    </div>







    <script src='https://cdn.jsdelivr.net/npm/bootstrap@5.2.0-beta1/dist/js/bootstrap.bundle.min.js'
        integrity='sha384-pprn3073KE6tl6bjs2QrFaJGz5/SUsLqktiwsUTF55Jfv3qYSDhgCecCxMW52nD2'
        crossorigin='anonymous'></script>
</body>

</html>






";

			System.IO.File.WriteAllText("permiso.html", plantilla);



			var uri = "permiso.html";
			var psi = new System.Diagnostics.ProcessStartInfo();
			psi.UseShellExecute = true;
			psi.FileName = uri;
			System.Diagnostics.Process.Start(psi);
			Console.WriteLine("salida con exito");


		}

	public static void color_R()
	{

		Random r = new Random();

		int coco = r.Next(1, 9);

		if (coco == 1)
		{
			Console.ForegroundColor = ConsoleColor.Blue;
		}
		else if (coco == 2)
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
		}
		else if (coco == 3)
		{
			Console.ForegroundColor = ConsoleColor.Green;
		}
		else if (coco == 4)
		{
			Console.ForegroundColor = ConsoleColor.DarkGreen;
		}
		else if (coco == 5)
		{
			Console.ForegroundColor = ConsoleColor.Magenta;
		}
		else if (coco == 6)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
		}
		else if (coco == 7)
		{
			Console.ForegroundColor = ConsoleColor.Gray;
		}
		else if (coco == 8)
		{
			Console.ForegroundColor = ConsoleColor.DarkRed;
		}

		else if (coco == 9)
		{
			Console.ForegroundColor = ConsoleColor.DarkBlue;
		}



	}


	public static void Acerca_de()
	{
		color_R();
		Console.WriteLine(@"
	  /$$$$$$   /$$     /$$                              
	 /$$__  $$ | $$    |__/                              
	| $$  \__//$$$$$$   /$$ /$$    /$$ /$$$$$$  /$$$$$$$ 
	|  $$$$$$|_  $$_/  | $$|  $$  /$$//$$__  $$| $$__  $$
	 \____  $$ | $$    | $$ \  $$/$$/| $$$$$$$$| $$  \ $$
	 /$$  \ $$ | $$ /$$| $$  \  $$$/ | $$_____/| $$  | $$
	|  $$$$$$/ |  $$$$/| $$   \  $/  |  $$$$$$$| $$  | $$
	 \______/   \___/  |__/    \_/    \_______/|__/  |__/
                                                     
	 ___   ___  ___   ___        ___    __   ___  ___ 
	(__ \ / _ \(__ \ (__ \ ___  / _ \  /. | | __)(__ )
	 / _/( (_) )/ _/  / _/(___)( (_) )(_  _)|__ \ / / 
	(____)\___/(____)(____)     \___/   (_) (___/(_/                                                       
                                             
"); color_R();
		Console.WriteLine(@"

matricula : 2022-0457
nombre : Stiven 
apellido : de la rosa brito 







");
	}
	}


	public class Root
{
	public string Cedula { get; set; }
	public string Nombres { get; set; }
	public string Apellido1 { get; set; }
	public string Apellido2 { get; set; }
	public string FechaNacimiento { get; set; }
	public string LugarNacimiento { get; set; }
	public string IdSexo { get; set; }
	public string IdEstadoCivil { get; set; }
	public string IDEstatus { get; set; }
	public object EstatusCedulaAzul { get; set; }
	public string CedulaAnterior { get; set; }
	public bool ok { get; set; }
	public string foto { get; set; }
}