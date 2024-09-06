using System;

class Lista
{
	private static List<Motoritas> Motoritas = new List<Motoritas>();



    public static List<Motoritas> Listamotoritas()
    {

        return Motoritas;
    }
	public static void Guardar (Motoritas motoritas)
    {
        try
        {
            Motoritas.Remove(motoritas);
        }
        catch (Exception)
        {

            throw;
        }
        Motoritas.Add(motoritas);
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(Motoritas);
        System.IO.File.WriteAllText("motoritas.json", json);
    }
    public static void Actualizar(Motoritas motoritas)
    {
        try
        {
            Motoritas.Remove(motoritas);
        }
        catch (Exception)
        {

            throw;
        };

        Motoritas.Add(motoritas);


        var json = Newtonsoft.Json.JsonConvert.SerializeObject(Motoritas);
        System.IO.File.WriteAllText("motoritas.json",json);
    }
    public static void Leer()
    {
        Motoritas = new List<Motoritas>();
        if (System.IO.File.Exists("motoritas.json"))
        {
            var json = System.IO.File.ReadAllText("motoritas.json");


            Motoritas = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Motoritas>>(json);



    }
}
}