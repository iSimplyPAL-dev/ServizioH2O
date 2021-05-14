Imports log4net
Imports RemotingInterfaceMotoreH2O.RemotingInterfaceMotoreH2O
Imports RemotingInterfaceMotoreH2O.MotoreH2o.Oggetti
Imports CreaFatturaNota

Namespace ServizioMotoreH2OSRV
    ''' <summary>
    ''' Classe rende disponibili le interfacce di calcolo 
    ''' </summary>
    Public Class MotoreH2O
        Inherits MarshalByRefObject : Implements IH2O
        Private Shared ReadOnly log As ILog = LogManager.GetLogger(GetType(MotoreH2O))

        Public Sub New()
            log.Debug("Istanziata la classe MotoreH2O")
        End Sub
        ''' <summary>
        ''' funzione che calcola il ruolo in base ai parametri passati
        ''' </summary>
        ''' <param name="ForzaQuotaFissa">intero parametro di configurazione ambiente se 1 la quota fissa viene calcolata anche se contatore esente acqua</param>
        ''' <param name="nTipoCalcoloFattura">intero parametro di configurazione ambiente che indica con quale criterio di raggruppamento calcolare</param>
        ''' <param name="oListContatori">lista oggetto di tipo objContatore con i dati da calcolare</param>
        ''' <param name="oMyTariffe">oggetto di tipo ObjTariffe con le tariffe da utilizzare per il calcolo</param>
        ''' <param name="sAnno">stringa anno di calcolo</param>
        ''' <param name="sOperatore">stringa operatore che esegue l'operazione</param>
        ''' <returns>oggetto di tipo ObjTotRuoloFatture contenente il ruolo calcolato con relativi documenti</returns>
        ''' <remarks></remarks>
        Public Function CreaRuoloH2O(ByVal ForzaQuotaFissa As Integer, ByVal nTipoCalcoloFattura As Integer, ByVal oListContatori() As objContatore, ByVal oMyTariffe As ObjTariffe, ByVal sAnno As String, ByVal sOperatore As String) As ObjTotRuoloFatture Implements IH2O.CreaRuoloH2O
            Try
                log.Debug("Inizio MotoreH2O::CreaRuoloH2O")
                log.Info("Inizio MotoreH2O::CreaRuoloH2O")

                Dim oClsElaboraRuoloH2O As New ClsElaborazione

                Return oClsElaboraRuoloH2O.CreaRuoloH2O(ForzaQuotaFissa, nTipoCalcoloFattura, oListContatori, oMyTariffe, System.Configuration.ConfigurationSettings.AppSettings("BaseTempo").ToString(), sAnno, sOperatore)
            Catch Err As Exception
                Throw New Exception(Err.Message & "::" & Err.StackTrace)
            End Try
        End Function
        ''' <summary>
        ''' funzione che calcola il consumo in base ai parametri passati
        ''' </summary>
        ''' <param name="nLetturaPrec">intero valore lettura precedente</param>
        ''' <param name="nLetturaAtt">intero valore lettura attuale</param>
        ''' <param name="nConsumoSubContatore">intero valore consumo subcontatore</param>
        ''' <param name="nFondoScala">intero valore fondo scala contatore</param>
        ''' <returns>intero consumo calcolato</returns>
        ''' <remarks></remarks>
        Public Function CalcolaConsumo(ByVal nLetturaPrec As Integer, ByVal nLetturaAtt As Integer, ByVal nConsumoSubContatore As Integer, ByVal nFondoScala As Integer) As Integer Implements IH2O.CalcolaConsumo
            Try
                log.Debug("Inizio MotoreH2O::CalcolaConsumo")
                log.Info("Inizio MotoreH2O::CalcolaConsumo")

                Dim oClsElaboraRuoloH2O As New ClsElaborazione

                Return oClsElaboraRuoloH2O.CalcolaConsumo(nLetturaPrec, nLetturaAtt, nConsumoSubContatore, nFondoScala)
            Catch Err As Exception
                Throw New Exception(Err.Message & "::" & Err.StackTrace)
            End Try
        End Function
        ''' <summary>
        ''' funzione che calcola l'intervallo di tempo di consumo in base ai parametri passati
        ''' </summary>
        ''' <param name="tDataPrecedente">data data lettura precedente</param>
        ''' <param name="tDataAttuale">data data lettura attuale</param>
        ''' <param name="nBaseTempo">intero indica l'intervallo di tempo da utilizzare per il calcolo</param>
        ''' <returns>intero intervallo di tempo calcolato</returns>
        ''' <remarks></remarks>
        Public Function CalcolaGiorni(ByVal tDataPrecedente As Date, ByVal tDataAttuale As Date, ByVal nBaseTempo As Integer) As Integer Implements IH2O.CalcolaGiorni
            Try
                log.Debug("Inizio MotoreH2O::CalcolaGiorni")
                log.Info("Inizio MotoreH2O::CalcolaGiorni")

                Dim oClsElaboraRuoloH2O As New ClsElaborazione

                Return oClsElaboraRuoloH2O.CalcolaGiorni(tDataPrecedente, tDataAttuale, nBaseTempo)
            Catch Err As Exception
                Throw New Exception(Err.Message & "::" & Err.StackTrace)
            End Try
        End Function
        ''' <summary>
        ''' funzione che calcola il dovuto in base ai parametri passati
        ''' </summary>
        ''' <param name="ForzaQuotaFissa">intero parametro di configurazione ambiente se 1 la quota fissa viene calcolata anche se contatore esente acqua</param>
        ''' <param name="oMyContatore">oggetto di tipo objContatore con i dati da calcolare</param>
        ''' <param name="oTariffe">oggetto di tipo ObjTariffe con le tariffe da utilizzare per il calcolo</param>
        ''' <param name="sOperatore">stringa operatore che esegue l'operazione</param>
        ''' <param name="bIsUnaTantum">booleano indica se deve essere applicato il nolo unatantum</param>
        ''' <param name="oFattura">out oggetto di tipo ObjFattura viene aggiornato con gli importi calcolati</param>
        ''' <returns>intero 1 se andato a buon fine altrimenti 0</returns>
        ''' <remarks></remarks>
        Public Function CalcolaDovutoH2O(ByVal ForzaQuotaFissa As Integer, ByVal oMyContatore As objContatore, ByVal oTariffe As ObjTariffe, ByVal sOperatore As String, ByVal bIsUnaTantum As Boolean, ByRef oFattura As ObjFattura) As Integer Implements IH2O.CalcolaDovutoH2O
            Dim x, myReturn As Integer

            Try
                log.Debug("Inizio MotoreH2O::CalcolaDovutoH2O")
                log.Info("Inizio MotoreH2O::CalcolaDovutoH2O")

                Dim oClsElaboraRuoloH2O As New ClsElaborazione

                For x = 0 To oMyContatore.oListLetture.GetUpperBound(0)
                    myReturn = oClsElaboraRuoloH2O.CalcolaDovutoH2O(ForzaQuotaFissa, oMyContatore, oTariffe, sOperatore, x, bIsUnaTantum, oFattura)
                Next
                Return myReturn
            Catch Err As Exception
                Throw New Exception(Err.Message & "::" & Err.StackTrace)
            End Try
        End Function
    End Class
End Namespace
