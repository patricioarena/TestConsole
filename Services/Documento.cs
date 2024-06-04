using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Services;

namespace TestConsole.Services
{


    public class Documento1
    {
        public Documento1(int id, int idPresentacion, Guid idDocumento)
        {
            this.id = id;
            this.idPresentacion = idPresentacion;
            this.idDocumento = idDocumento;
        }

        public int id { get; set; }
        public int idPresentacion { get; set; }
        public Guid idDocumento { get; set; }
    }

    public class Documento2 
    {
        public Documento2(int id, int idPresentacion, Guid unicIdDocumento, bool attachedCorrectly)
        {
            Id = id;
            this.idPresentacion = idPresentacion;
            this.unicIdDocumento = unicIdDocumento;
            this.attachedCorrectly = attachedCorrectly;
        }

        public int Id { get; set; }
        public int idPresentacion { get; set; }
        public Guid unicIdDocumento { get; set; }
        public bool attachedCorrectly { get; set; }
    }

    public interface IDocumentoService 
    {
        List<Documento2> CompararListas(List<Documento1> documentosPresentacion, List<Documento2> documentosPresentacionSCBA);
        //List<Documento2> comparacionList(List<Documento1> documento1s, List<Documento2> documento2s);
    }

    public class DocumentoService : IDocumentoService
    {
        public DocumentoService()
        {
        }

        //public List<Documento2> comparacionList(List<Documento1> documento1s, List<Documento2> documento2s) {

        //    List<Documento2> newList = new List<Documento2>();

        //    foreach (var doc in documento1s) {
        //        var idPresentacion = doc.idPresentacion;
        //        var idDocumento = doc.idDocumento;

        //        foreach (var doc2 in documento2s)
        //        {
        //            var idPresentacion2 = doc2.idPresentacion;
        //            var unicIdDocumento = doc2.unicIdDocumento;

        //            if (idPresentacion == idPresentacion2 && idDocumento == unicIdDocumento) 
        //            {
        //                newList.Add(doc2);
        //            }
        //        }
        //    }
        //    return newList;
        //}

        public List<Documento2> CompararListas(List<Documento1> documentosPresentacion, List<Documento2> documentosPresentacionSCBA)
        {
            var diccionarioDocumentosPresentacion = documentosPresentacion.ToDictionary(docPres => (docPres.idPresentacion, docPres.idDocumento));
            var listDocumentosToAddInXML = documentosPresentacionSCBA
                .Where(docPresSCBA => !diccionarioDocumentosPresentacion.TryGetValue((docPresSCBA.idPresentacion, docPresSCBA.unicIdDocumento), out _))
                .ToList();

            return listDocumentosToAddInXML;
        }
    }
}
