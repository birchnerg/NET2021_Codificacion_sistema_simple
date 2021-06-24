using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Entities;
using Business.Logic;

namespace UI.Consola
{
    public class Usuarios
    {
        private Business.Logic.UsuarioLogic _UsuarioNegocio;
        public Usuarios() 
        {
            UsuarioNegocio = new UsuarioLogic();
        }
        public Business.Logic.UsuarioLogic UsuarioNegocio
        {
            get { return _UsuarioNegocio; }
            set { _UsuarioNegocio = value; }
        }
        public void Menu()
        {
            ConsoleKeyInfo opcionUsuario;
            do
            {
                Console.Clear();
                Console.WriteLine("1 – Listado General");
                Console.WriteLine("2 – Consulta");
                Console.WriteLine("3 – Agregar");
                Console.WriteLine("4 - Modificar");
                Console.WriteLine("5 - Eliminar");
                Console.WriteLine("6 - Salir");
                opcionUsuario = Console.ReadKey();
                switch (opcionUsuario.Key)
                {
                    case (ConsoleKey.D1):
                    case (ConsoleKey.NumPad1):
                        ListadoGeneral();
                        break;
                    case (ConsoleKey.D2):
                    case (ConsoleKey.NumPad2):
                        Consulta();
                        break;
                    case (ConsoleKey.D3):
                    case (ConsoleKey.NumPad3):
                        Agregar();
                        break;
                    case (ConsoleKey.D4):
                    case (ConsoleKey.NumPad4):
                        Modificar();
                        break;
                    case (ConsoleKey.D5):
                    case (ConsoleKey.NumPad5):
                        Eliminar();
                        break;
                    case (ConsoleKey.D6):
                    case (ConsoleKey.NumPad6):
                        Console.WriteLine("");
                        Console.WriteLine("Presione cualquier tecla para salir");
                        Console.ReadLine();
                        break;
                }
            } while (opcionUsuario.Key != ConsoleKey.D6 && opcionUsuario.Key != ConsoleKey.NumPad6);
        }

        public void ListadoGeneral()
        {
            Console.Clear();
            Console.WriteLine("1– Listado General");
            foreach (Usuario usr in UsuarioNegocio.GetAll())
            {
                MostrarDatos(usr);
            }
            Console.WriteLine("Presione cualquier tecla para volver al menu principal");
            Console.ReadKey();
        }
        public void MostrarDatos(Usuario usr)
        {
            Console.WriteLine("Usuario: {0}", usr.ID);
            Console.WriteLine("\t\tNombre: {0}", usr.Nombre);
            Console.WriteLine("\t\tApellido: {0}", usr.Apellido);
            Console.WriteLine("\t\tNombre de Usuario: {0}", usr.NombreUsuario);
            Console.WriteLine("\t\tClave: {0}", usr.Clave);
            Console.WriteLine("\t\tEmail: {0}", usr.Email);
            Console.WriteLine("\t\tHabilitado: {0}", usr.Habilitado);
            Console.WriteLine("");
        }
        public void Consulta()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("2– Consulta");
                Console.WriteLine("Ingrese el ID del usuario a consultar: ");
                int id = int.Parse(Console.ReadLine());
                this.MostrarDatos(UsuarioNegocio.GetOne(id));
            }
            catch (FormatException)
            {
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally 
            {
                Console.WriteLine("Presione una tecla para volver al menu");
                Console.ReadKey();
            }
        }
        public void Agregar()
        {
            Usuario usuario = new Usuario();
            Console.Clear();
            Console.WriteLine("3– Agregar"); 
            Console.Write("Ingrese Nombre: ");
            usuario.Nombre = Console.ReadLine();
            Console.Write("Ingrese Apellido: ");
            usuario.Apellido = Console.ReadLine();
            Console.Write("Ingrese Nombre de usuario: ");
            usuario.NombreUsuario = Console.ReadLine();

            ///Verificacion de clave
            string clave;
            do
            {
                Console.Write("Ingrese clave: ");
                clave = Console.ReadLine();
                if (!ValidadoresLogic.ValidarClave(clave))
                {
                    Console.WriteLine("La clave debe contener por lo menos 8 caracteres");
                }

            } while (!ValidadoresLogic.ValidarClave(clave));
            usuario.Clave = clave;

            ///Verificacion de email ingresado correcto
            string email;
            do
            {
                Console.Write("Ingrese Email: ");
                email = Console.ReadLine();
                if (!ValidadoresLogic.ValidarEmail(email))
                {
                    Console.WriteLine("Ingrese un email valido");
                }

            } while (!ValidadoresLogic.ValidarEmail(email));
            usuario.Email = email;

            Console.Write("Ingrese Habilitacion de Usuario (1-Si/otro-No): ");
            usuario.Habilitado = Console.ReadLine() == "1";
            usuario.State = BusinessEntity.States.New;
            UsuarioNegocio.Save(usuario);
            Console.WriteLine();
            Console.WriteLine("ID: {0}", usuario.ID);
            Console.WriteLine("Presione una tecla para volver al menu");
            Console.ReadKey();
        }
        public void Modificar()
        {
            try 
            {
                Console.Clear();
                Console.WriteLine("4 - Modificar");
                Console.WriteLine("Ingrese el ID del usuario a modificar: ");
                int id = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(id);
                if (usuario != null)
                {
                    Console.Write("Ingrese Nombre: ");
                    usuario.Nombre = Console.ReadLine();
                    Console.Write("Ingrese Apellido: ");
                    usuario.Apellido = Console.ReadLine();
                    Console.Write("Ingrese Nombre de usuario: ");
                    usuario.NombreUsuario = Console.ReadLine();
                    ///Verificacion de clave
                    string clave;
                    do
                    {
                        Console.Write("Ingrese clave: ");
                        clave = Console.ReadLine();
                        if (!ValidadoresLogic.ValidarClave(clave))
                        {
                            Console.WriteLine("La clave debe contener por lo menos 8 caracteres");
                        }

                    } while (!ValidadoresLogic.ValidarClave(clave));
                    usuario.Clave = clave;

                    ///Verificacion de email ingresado correcto
                    string email;
                    do
                    {
                        Console.Write("Ingrese Email: ");
                        email = Console.ReadLine();
                        if (!ValidadoresLogic.ValidarEmail(email))
                        {
                            Console.WriteLine("Ingrese un email valido");
                        }

                    } while (!ValidadoresLogic.ValidarEmail(email));
                    usuario.Email = email;
                    Console.Write("Ingrese Habilitacion de Usuario (1-Si/otro-No): ");
                    usuario.Habilitado = Console.ReadLine() == "1";
                    usuario.State = BusinessEntity.States.Modified;
                    UsuarioNegocio.Save(usuario);
                }
                else
                {
                    Console.WriteLine("La ID ingresada no coincide con la de ningún usuario");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para volver al menu");
                Console.ReadKey();
            }
        }
        public void Eliminar()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("5 - Eliminar");
                Console.WriteLine("Ingrese el ID del usuario a eliminar: ");
                int id = int.Parse(Console.ReadLine());
                Usuario usuario = UsuarioNegocio.GetOne(id);
                if (usuario != null)
                {
                    UsuarioNegocio.Delete(id);
                    Console.WriteLine("Usuario {0} eliminado correctamente", id);
                }
                else
                {
                    Console.WriteLine("La ID ingresada no coincide con la de ningún usuario");
                }          
            }
            catch (FormatException)
            {
                Console.WriteLine("La ID ingresada debe ser un número entero");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla para volver al menu");
                Console.ReadKey();
            }
        }
        
    }
}




