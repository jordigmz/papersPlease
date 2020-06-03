using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media.Animation;
using Microsoft.VisualBasic;

namespace PapersPlease
{
    class ListaPasaportes
    {
        List<Pasaporte> pasaportes;
        List<Pasaporte> pasaportesErroneos;
        Jugador j;

        public ListaPasaportes()
        {
            j = new Jugador();
            pasaportes = new List<Pasaporte>();
            pasaportesErroneos = new List<Pasaporte>();
        }

        public List<Pasaporte> GetPasaportes()
        {
            return pasaportes;
        }
        public void SetPasaportes(List<Pasaporte> pasaportes)
        {
            this.pasaportes = pasaportes;
        }

        public List<Pasaporte> GetPasaportesErroneos()
        {
            return pasaportesErroneos;
        }
        public void SetPasaportesErroneos(List<Pasaporte> pasaportesErroneos)
        {
            this.pasaportesErroneos = pasaportesErroneos;
        }

        public void AddCorrecto(Pasaporte pasaporte)
        {
            pasaportes.Add(pasaporte);
        }
        public void AddErroneo(Pasaporte pasaporte)
        {
            pasaportesErroneos.Add(pasaporte);
        }

        public void Crear()
        {
            try
            {
                if (j.GetNombreJugador() == "")
                {
                    do
                    {
                        j.SetNombreJugador(Interaction.InputBox("Por favor, inserte un alias.", "Nombre", "", -1, -1));

                    } while (j.GetNombreJugador() == "");

                    MessageBox.Show("Bienvenid@ " + j.GetNombreJugador() + "!");
                }
                
                string linea = "", nombreTemp = "", apellidoTemp = "", dniTemp = "", fechaNacimientoTemp = "";
                int cont = 1, cont2=1;

                StreamReader nombresC = File.OpenText(@"imagenes\assets\text\correcto\nombres.txt");
                StreamReader apellidosC = File.OpenText(@"imagenes\assets\text\correcto\apellidos.txt");
                StreamReader dniC = File.OpenText(@"imagenes\assets\text\correcto\dni.txt");
                StreamReader fechasNacimientoC = File.OpenText(@"imagenes\assets\text\correcto\fechasNacimiento.txt");

                do
                {
                    linea = nombresC.ReadLine();
                    if (linea != null)
                    {
                        nombreTemp=linea;
                    }

                    linea = apellidosC.ReadLine();
                    if (linea != null)
                    {
                        apellidoTemp = linea;
                    }

                    linea = dniC.ReadLine();
                    if (linea != null)
                    {
                        dniTemp = linea;
                    }

                    linea = fechasNacimientoC.ReadLine();
                    if (linea != null)
                    {
                        fechaNacimientoTemp = linea;
                    }

                    if (linea != null)
                    {
                        AddCorrecto(new Pasaporte(
                            Directory.GetCurrentDirectory() + @"\imagenes\assets\personajes\correcto\p" + cont + ".png",
                            Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\correcto\d" + cont + ".png",
                            Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\correcto\d" + cont + ".png",
                            nombreTemp,
                            apellidoTemp,
                            dniTemp,
                            Convert.ToDateTime(fechaNacimientoTemp)
                        ));

                        cont++;
                    }

                } while (linea != null);

                nombresC.Close();
                apellidosC.Close();
                dniC.Close();
                fechasNacimientoC.Close();

                StreamReader nombresE = File.OpenText(@"imagenes\assets\text\error\nombres.txt");
                StreamReader apellidosE = File.OpenText(@"imagenes\assets\text\error\apellidos.txt");
                StreamReader dniE = File.OpenText(@"imagenes\assets\text\error\dni.txt");
                StreamReader fechasNacimientoE = File.OpenText(@"imagenes\assets\text\error\fechasNacimiento.txt");

                do
                {
                    linea = nombresE.ReadLine();
                    if (linea != null)
                    {
                        nombreTemp = linea;
                    }

                    linea = apellidosE.ReadLine();
                    if (linea != null)
                    {
                        apellidoTemp = linea;
                    }

                    linea = dniE.ReadLine();
                    if (linea != null)
                    {
                        dniTemp = linea;
                    }

                    linea = fechasNacimientoE.ReadLine();
                    if (linea != null)
                    {
                        fechaNacimientoTemp = linea;
                    }

                    if (linea != null)
                    {
                        AddErroneo(new Pasaporte(
                            Directory.GetCurrentDirectory() + @"\imagenes\assets\personajes\error\p" + cont2 + ".png",
                            Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\error\d" + cont2 + ".png",
                            Directory.GetCurrentDirectory() + @"\imagenes\assets\documentacion\error\d" + cont2 + ".png",
                            nombreTemp,
                            apellidoTemp,
                            dniTemp,
                            Convert.ToDateTime(fechaNacimientoTemp)
                        ));

                        cont2++;
                    }

                } while (linea != null);

                nombresE.Close();
                apellidosE.Close();
                dniE.Close();
                fechasNacimientoE.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el fichero.");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("El nombre del fichero es demasiado largo.");
            }
            catch (IOException)
            {
                MessageBox.Show("Error en el fichero.");
            }
        }

        public void Cargar(string partida)
        {
            try
            {
                string linea = "", personajeImagenTemp = "", pasaporteImagenTemp = "", visadoImagenTemp = "", nombreTemp = "", apellidoTemp = "", dniTemp = "", fechaNacimientoTemp = "";

                StreamReader fr = File.OpenText(partida);

                linea = fr.ReadLine();
                if (linea != null)
                {
                    j.SetNombreJugador(linea);
                }

                linea = fr.ReadLine();
                if (linea != null)
                {
                    j.SetContadorDias(Convert.ToInt32(linea));
                }

                linea = fr.ReadLine();
                if (linea != null)
                {
                    j.SetAhorros(Convert.ToInt32(linea));
                }

                fr.Close();
                
                StreamReader fC = File.OpenText(partida.Substring(0, partida.Length - 4) + "Correctos.txt");

                do
                {
                    linea = fC.ReadLine();
                    if (linea != null)
                    {
                        personajeImagenTemp = linea;
                    }

                    linea = fC.ReadLine();
                    if (linea != null)
                    {
                        pasaporteImagenTemp = linea;
                    }

                    linea = fC.ReadLine();
                    if (linea != null)
                    {
                        visadoImagenTemp = linea;
                    }

                    linea = fC.ReadLine();
                    if (linea != null)
                    {
                        nombreTemp = linea;
                    }

                    linea = fC.ReadLine();
                    if (linea != null)
                    {
                        apellidoTemp = linea;
                    }

                    linea = fC.ReadLine();
                    if (linea != null)
                    {
                        dniTemp = linea;
                    }

                    linea = fC.ReadLine();
                    if (linea != null)
                    {
                        fechaNacimientoTemp = linea;
                    }

                    if (linea != null)
                    {
                        AddCorrecto(new Pasaporte(
                            personajeImagenTemp,
                            pasaporteImagenTemp,
                            visadoImagenTemp,
                            nombreTemp,
                            apellidoTemp,
                            dniTemp,
                            Convert.ToDateTime(fechaNacimientoTemp)
                        ));
                    }

                } while (linea != null);

                fC.Close();

                StreamReader fE = File.OpenText(partida.Substring(0, partida.Length - 4) + "Erroneos.txt");

                do
                {
                    linea = fE.ReadLine();
                    if (linea != null)
                    {
                        personajeImagenTemp = linea;
                    }

                    linea = fE.ReadLine();
                    if (linea != null)
                    {
                        pasaporteImagenTemp = linea;
                    }

                    linea = fE.ReadLine();
                    if (linea != null)
                    {
                        visadoImagenTemp = linea;
                    }

                    linea = fE.ReadLine();
                    if (linea != null)
                    {
                        nombreTemp = linea;
                    }

                    linea = fE.ReadLine();
                    if (linea != null)
                    {
                        apellidoTemp = linea;
                    }

                    linea = fE.ReadLine();
                    if (linea != null)
                    {
                        dniTemp = linea;
                    }

                    linea = fE.ReadLine();
                    if (linea != null)
                    {
                        fechaNacimientoTemp = linea;
                    }

                    if (linea != null)
                    {
                        AddErroneo(new Pasaporte(
                            personajeImagenTemp,
                            pasaporteImagenTemp,
                            visadoImagenTemp,
                            nombreTemp,
                            apellidoTemp,
                            dniTemp,
                            Convert.ToDateTime(fechaNacimientoTemp)
                        ));
                    }

                } while (linea != null);

                fE.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el fichero.");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("El nombre del fichero es demasiado largo.");
            }
            catch (IOException)
            {
                MessageBox.Show("Error en el fichero.");
            }
        }

        public void Guardar(string partida, string ahorros, string dias, List<Pasaporte> pCorrecto, List<Pasaporte> pErroneo)
        {
            try
            {
                StreamWriter fw = File.CreateText(partida + ".txt");

                fw.WriteLine(j.GetNombreJugador());
                fw.WriteLine(ahorros);
                fw.WriteLine(dias);

                fw.Close();

                StreamWriter fC = File.CreateText(partida + "Correctos.txt");

                foreach (Pasaporte p in pCorrecto)
                {
                    fC.WriteLine(p.GetPersonajeImagen());
                    fC.WriteLine(p.GetPasaporteImagen());
                    fC.WriteLine(p.GetVisadoImagen());
                    fC.WriteLine(p.GetNombre());
                    fC.WriteLine(p.GetApellido());
                    fC.WriteLine(p.GetDni());
                    fC.WriteLine(p.GetFechaNacimiento().ToString());
                }

                fC.Close();

                StreamWriter fE = File.CreateText(partida + "Erroneos.txt");

                foreach (Pasaporte p in pErroneo)
                {
                    fE.WriteLine(p.GetPersonajeImagen());
                    fE.WriteLine(p.GetPasaporteImagen());
                    fE.WriteLine(p.GetVisadoImagen());
                    fE.WriteLine(p.GetNombre());
                    fE.WriteLine(p.GetApellido());
                    fE.WriteLine(p.GetDni());
                    fE.WriteLine(p.GetFechaNacimiento().ToString());
                }

                fE.Close();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el fichero.");
            }
            catch (PathTooLongException)
            {
                MessageBox.Show("El nombre del fichero es demasiado largo.");
            }
            catch (IOException)
            {
                MessageBox.Show("Error en el fichero.");
            }
        }
    }
}
