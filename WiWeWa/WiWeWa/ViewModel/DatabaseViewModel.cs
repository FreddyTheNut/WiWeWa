using System;
using System.Collections.Generic;
using System.Text;
using WiWeWa.ViewModel.ModelViewModel;
using Xamarin.Forms;

namespace WiWeWa.ViewModel
{
    class DatabaseViewModel
    {
       //string path = DependencyService.Get<IDependency>().GetLocalFilePath("Datenbank.sql");
       //
       //OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|/IHKPruefungen.accdb");
       //OleDbCommand command = new OleDbCommand();
       //OleDbDataReader dataReader;
       //
       //public DatabaseViewModel()
       //{
       //    connection.Open();
       //    command.CommandType = CommandType.Text;
       //}
       //
       //public List<PruefungViewModel> GetPruefungen()
       //{
       //    List<PruefungViewModel> pruefungListe = new List<PruefungViewModel>();
       //
       //    command = new OleDbCommand("SELECT * FROM Pruefung", connection);
       //    dataReader = command.ExecuteReader();
       //
       //    while (dataReader.Read())
       //    {
       //        int id = Convert.ToInt32(Pruefen(dataReader[0]));
       //        int jahr = Convert.ToInt32(Pruefen(dataReader[1]));
       //        String jahreszeit = Convert.ToString(Pruefen(dataReader[2]));
       //        String situation = Convert.ToString(Pruefen(dataReader[3]));
       //
       //        pruefungListe.Add(
       //            new PruefungViewModel()
       //            {
       //                Id = id, Jahr = jahr, Jahreszeit = jahreszeit, Situation = situation
       //            });
       //    }
       //
       //    return pruefungListe;
       //}
       //
       //public List<FrageViewModel> GetFragen()
       //{
       //    List<FrageViewModel> frageListe = new List<FrageViewModel>();
       //
       //    command = new OleDbCommand("SELECT * FROM Frage", connection);
       //    dataReader = command.ExecuteReader();
       //
       //    while (dataReader.Read())
       //    {
       //        int id = Convert.ToInt32(Pruefen(dataReader[0]));
       //        int pruefungNR = Convert.ToInt32(Pruefen(dataReader[1]));
       //        int aufgabe = Convert.ToInt32(Pruefen(dataReader[2]));
       //        String frageText = Convert.ToString(Pruefen(dataReader[3]));
       //        String zusatzText = Convert.ToString(Pruefen(dataReader[4]));
       //        int antwortmoeglichkeiten = Convert.ToInt32(Pruefen(dataReader[5]));
       //        int richtigeAnzahl = Convert.ToInt32(Pruefen(dataReader[6]));
       //
       //        if (frageText != "")
       //        {
       //            frageListe.Add(
       //                new FrageViewModel()
       //                {
       //                    Id = id, PruefungNR = pruefungNR, Aufgabe = aufgabe, FrageText = frageText, ZusatzText = zusatzText, Antwortmoeglichkeiten = antwortmoeglichkeiten, RichtigeAnzahl = richtigeAnzahl
       //                });
       //        }
       //    }
       //
       //    return frageListe;
       //}
       //
       //public List<FrageViewModel> GetSelectedFragen(List<int> sf)
       //{
       //    List<FrageViewModel> frageListe = new List<FrageViewModel>();
       //
       //    String commandText = "SELECT * FROM Frage WHERE PruefungNR IN (";
       //
       //    commandText += string.Join(",", sf) + ")";
       //
       //    command = new OleDbCommand(commandText, connection);
       //    dataReader = command.ExecuteReader();
       //
       //    while (dataReader.Read())
       //    {
       //        int id = Convert.ToInt32(Pruefen(dataReader[0]));
       //        int pruefungNR = Convert.ToInt32(Pruefen(dataReader[1]));
       //        int aufgabe = Convert.ToInt32(Pruefen(dataReader[2]));
       //        String frageText = Convert.ToString(Pruefen(dataReader[3]));
       //        String zusatzText = Convert.ToString(Pruefen(dataReader[4]));
       //        int antwortmoeglichkeiten = Convert.ToInt32(Pruefen(dataReader[5]));
       //        int richtigeAnzahl = Convert.ToInt32(Pruefen(dataReader[6]));
       //
       //        if (frageText != "")
       //        {
       //            frageListe.Add(
       //                new FrageViewModel()
       //                {
       //                    Id = id,
       //                    PruefungNR = pruefungNR,
       //                    Aufgabe = aufgabe,
       //                    FrageText = frageText,
       //                    ZusatzText = zusatzText,
       //                    Antwortmoeglichkeiten = antwortmoeglichkeiten,
       //                    RichtigeAnzahl = richtigeAnzahl
       //                });
       //        }
       //    }
       //
       //    return frageListe;
       //}
       //
       //public List<AntwortViewModel> GetAntworten()
       //{
       //    List<AntwortViewModel> antwortListe = new List<AntwortViewModel>();
       //
       //    command = new OleDbCommand("SELECT * FROM Antwort", connection);
       //    dataReader = command.ExecuteReader();
       //
       //    while (dataReader.Read())
       //    {
       //        int id = Convert.ToInt32(Pruefen(dataReader[0]));
       //        int frageNR = Convert.ToInt32(Pruefen(dataReader[1]));
       //        String antwortText = Convert.ToString(Pruefen(dataReader[2]));
       //        bool richtig = Convert.ToBoolean(Pruefen(dataReader[3]));
       //
       //        antwortListe.Add(
       //            new AntwortViewModel
       //            {
       //                Id = id, FrageNR = frageNR, AntwortText = antwortText, Richtig = richtig
       //            });
       //    }
       //
       //    return antwortListe;
       //}
       //
       //public void ConnectionEnd()
       //{
       //    command.Cancel();
       //    connection.Close();
       //}
       //
       //private object Pruefen(Object o)
       //{
       //    if (o == DBNull.Value)
       //    {
       //        return null;
       //    }
       //    else
       //    {
       //        return o;
       //    }
       //}
    }
}
