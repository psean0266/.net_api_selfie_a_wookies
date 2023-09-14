using SelfieAWookies.Core.Selfies.Domain;

namespace SelfieAWookies.Core.Domain
{
    public class Selfie
    {
        #region properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string? ImagePath { get; set; }
        public int WookieId { get; set; }
        public Wookie Wookie{ get; set; }   
        public int PictureId { get; set; }  
        public Picture Picture { get; set;}



        /* Methode de relation 2 ajouter l'Id et les relations se font automatiquement avec la convention
         public int WookieId
         
         */

        #endregion
    }
}
