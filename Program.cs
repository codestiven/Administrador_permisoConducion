bool condicionador = true;


Lista.Leer();

while (condicionador)
{
    Console.Clear();
    Clases.color_R();
    Console.WriteLine(@"
                                    ,-~ |
       ________________          o==]___|
      |                |            \ \
      |________________|            /\ \
 __  /  _,-----._      )           |  \ \.
|_||/_-~         `.   /()          |  /|]_|_____
  |//              \ |              \/ /_-~     ~-_
  //________________||              / //___________\
 //__|______________| \____________/ //___/-\ \~-_
((_________________/_-o___________/_//___/  /\,\  \
 |__/(  ((====)o===--~~                 (  ( (o/)  )
      \  ``==' /                         \  `--'  /
       `-.__,-'                           `-.__,-'




");
    Clases.color_R();
    Console.WriteLine(@"
Seleccione una opcion 

1 - Registrar motor
2 - Editar motor
3 - Ver mapa
4 - Imprimir licencia 
5 - aserca de mi
6 - salir
");
    Clases.color_R();
    Console.Write("ingrese la opcion deseada :");
    var entrada = Console.ReadLine();
    Clases.color_R();
    switch (entrada)
    {
        case "1":
        Console.Clear ();
            Clases.color_R();
            Clases.Registrar();

            Console.ReadKey();
            break;
        case "2":
            Clases.color_R();
            Console.Clear();
            Clases.Editar();

            Console.ReadKey();
            break;
        case "3":
            Console.Clear();

            Clases.Mapa();
            Console.ReadKey();
            break;
        case "4":
            Console.Clear();

            Clases.Permiso();

            break;
        case "5":
            Console.Clear();

            Clases.Acerca_de();
            Console.ReadKey();
            break;
        case "6":


            condicionador = false;


            break;

    }

}
