Imports System
Imports System.Collections
Imports RemotingInterfaceMotoreH2O.MotoreH2o.Oggetti

Namespace RemotingInterfaceMotoreH2O
    Public Interface IH2O
        ''' <summary>
        ''' funzione che calcola il ruolo in base ai parametri passati
        ''' </summary>
        ''' <param name="ForzaQuotaFissa">intero parametro di configurazione ambiente se 1 la quota fissa viene calcolata anche se contatore esente acqua</param>
        ''' <param name="nTipoCalcoloFattura">intero parametro di configurazione ambiente che indica con quale criterio di raggruppamento calcolare</param>
        ''' <param name="oListLettureFatt">lista oggetto di tipo objContatore con i dati da calcolare</param>
        ''' <param name="oMyTariffe">oggetto di tipo ObjTariffe con le tariffe da utilizzare per il calcolo</param>
        ''' <param name="sAnno">stringa anno di calcolo</param>
        ''' <param name="sOperatore">stringa operatore che esegue l'operazione</param>
        ''' <returns>oggetto di tipo ObjTotRuoloFatture contenente il ruolo calcolato con relativi documenti</returns>
        ''' <remarks></remarks>
        Function CreaRuoloH2O(ByVal ForzaQuotaFissa As Integer, ByVal nTipoCalcoloFattura As Integer, ByVal oListLettureFatt() As objContatore, ByVal oMyTariffe As ObjTariffe, ByVal sAnno As String, ByVal sOperatore As String) As ObjTotRuoloFatture
        ''' <summary>
        ''' funzione che calcola il consumo in base ai parametri passati
        ''' </summary>
        ''' <param name="nLetturaPrec">intero valore lettura precedente</param>
        ''' <param name="nLetturaAtt">intero valore lettura attuale</param>
        ''' <param name="nConsumoSubContatore">intero valore consumo subcontatore</param>
        ''' <param name="nFondoScala">intero valore fondo scala contatore</param>
        ''' <returns>intero consumo calcolato</returns>
        ''' <remarks></remarks>
        Function CalcolaConsumo(ByVal nLetturaPrec As Integer, ByVal nLetturaAtt As Integer, ByVal nConsumoSubContatore As Integer, ByVal nFondoScala As Integer) As Integer
        ''' <summary>
        ''' funzione che calcola l'intervallo di tempo di consumo in base ai parametri passati
        ''' </summary>
        ''' <param name="tDataPrecedente">data data lettura precedente</param>
        ''' <param name="tDataAttuale">data data lettura attuale</param>
        ''' <param name="nBaseTempo">intero indica l'intervallo di tempo da utilizzare per il calcolo</param>
        ''' <returns>intero intervallo di tempo calcolato</returns>
        ''' <remarks></remarks>
        Function CalcolaGiorni(ByVal tDataPrecedente As Date, ByVal tDataAttuale As Date, ByVal nBaseTempo As Integer) As Integer
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
        Function CalcolaDovutoH2O(ByVal ForzaQuotaFissa As Integer, ByVal oMyContatore As objContatore, ByVal oTariffe As ObjTariffe, ByVal sOperatore As String, ByVal bIsUnaTantum As Boolean, ByRef oFattura As ObjFattura) As Integer
    End Interface

    Public Class Util
        ''' <summary>
        ''' costante valore 0, indica che viene fatta una fattura per ogni lettura
        ''' </summary>
        ''' <remarks></remarks>
        Public Const FATTURA_PER_LETTURA As Integer = 0
        ''' <summary>
        ''' costante valore 1, indica che viene fatta una fattura per ogni matricola
        ''' </summary>
        ''' <remarks></remarks>
        Public Const FATTURA_PER_UTENTEMATRICOLA As Integer = 1
        ''' <summary>
        ''' costante valore 2, indica che viene fatta una fattura per ogni utente
        ''' </summary>
        ''' <remarks></remarks>
        Public Const FATTURA_PER_UTENTE As Integer = 2
    End Class
End Namespace
