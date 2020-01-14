using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRHHApp.model
{
    /// <summary>
    ///     Classe que representa una persona.
    /// </summary>
    /// <remarks>
    ///     Aquesta classe és essencial en el procés de facturació.
    /// </remarks>
    public class Persona
    {
        private String _NIF;
        private String nom;
        private DateTime dataNaixement;

        /// <summary>
        ///  Constructor de la classe Persona
        ///  Tipus de persona:
        ///  <list type="table">
        ///     <item><term>TE</term><description>Treballador Extern</description></item>
        ///     <item><term>TI</term><description>Treballador Intern</description></item>
        ///     <item><term>AL</term><description>Altres</description></item>
        ///  </list>
        ///  
        /// ![Persones](~/images/persones.jpg)
        /// # Titol principal
        /// ## Això és un títol secundari
        /// ### Títol nivell tres
        /// * primer
        /// * segon
        /// * tercer
        /// 
        /// 1. Paco
        /// 1. Maria
        /// 1. Pau
        /// 
        /// Text normal en **negreta**,  *cursiva*.
        /// 
        /// | id | descripcio|adreça|
        /// |----|-------------|----|
        /// | 1 | paco | C\ Viladecans, 3, 4-5  |
        /// | 2 | Maria |  Av\ Torrrents 45 |
        /// 
        /// ```csharp
        ///     int i = 0;
        ///     if(n>20) {
        ///         
        ///     }
        /// ```
        /// 
        /// 
        ///```plantUml
        ///Bob -> Alice : hello
        ///Alice -> Bob : Go Away
        ///```
        /// 
        /// 
        /// 
        /// </summary>
        /// <param name="NIF">NIF en format 99999999X. Obligatori. No pot estar repetit. </param>
        /// <param name="nom">Nom complet de la persona (inclou els cognoms). Mínim 2 caràcters. Obligatori.</param>
        /// <param name="dataNaixement">Data de naixement de la persona. No pot ser anterior al 1950.</param>
        /// 
        /// <example>
        ///     <code lang="csharp">
        ///         Persona p = new Persona("11111111A", "Paco Lucena", DateTime.Now);
        ///         String nom = p.Nom;
        ///     </code>
        ///     <code lang="csharp" source="..\model\Persona.cs" region="exempleConstructor"></code>
        /// </example>
        public Persona(string NIF, string nom, DateTime dataNaixement)
        {
            this.NIF = NIF;
            this.nom = nom;
            this.dataNaixement = dataNaixement;
        }

        /// <summary>
        ///  Calcula l'edat de la persona.
        /// </summary>
        /// <returns> retorna l'edat de la persona calculada a partir de la seva data de naixement.</returns>
        public int GetEdat()
        {
            return 0;
        }

        public string NIF
        {
            get => _NIF;
            set
            {
                if (value.Length != 9) throw new Exception("NIF invalid");
                _NIF = value;
            }
        }
        public string Nom { get => nom; set => nom = value; }
        public DateTime DataNaixement { get => dataNaixement; set => dataNaixement = value; }


#region exempleConstructor
  private void DemoConstructor()
  {
        Persona p = new Persona("11111111A", "Paco Lucena", DateTime.Now);
        String nom = p.Nom;
  }
#endregion

    }
}
