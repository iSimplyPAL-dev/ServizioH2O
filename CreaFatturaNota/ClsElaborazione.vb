Imports log4net
Imports RemotingInterfaceMotoreH2O.MotoreH2o.Oggetti

''' <summary>
''' Permette di elaborare il dovuto e di determinare le fatture.
''' La procedura di calcolo è stata suddivisa in varie funzioni una per ogni singolo blocco di tariffa
''' </summary>
''' <history>
''' 	[monicatarello]	21/10/2008	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class ClsElaborazione
    Private Shared Log As ILog = LogManager.GetLogger(GetType(ClsElaborazione))
    Public Const sCapitoloEnte As String = "0000"
    Public Const sCapitoloIva As String = "9996"
    Public Const sCapitoloArrotondamento As String = "9999"

    ''' <summary>
    ''' Calcola il ruolo in base ai parametri passati.
    ''' Per ogni utente ed in base al tipo di calcolo indicato viene creata una fattura con relativi importi.<br></br>
    ''' Per ogni lettura passata vengono determinati:<br />
    ''' - consumo (in base alla lettura precedente e alla lettura attuale togliendo il consumo del sub contatore)<br />
    ''' - giorni di consumo (in base alla data di lettura precedente e alla data di lettura attuale)<br />
    ''' </summary>
    ''' <param name="ForzaQuotaFissa">intero parametro di configurazione ambiente se 1 la quota fissa viene calcolata anche se contatore esente acqua</param>
    ''' <param name="nTipoCalcoloFattura">intero parametro di configurazione ambiente che indica con quale criterio di raggruppamento calcolare</param>
    ''' <param name="oListContatori">lista oggetto di tipo objContatore con i dati da calcolare</param>
    ''' <param name="oMyTariffe">oggetto di tipo ObjTariffe con le tariffe da utilizzare per il calcolo</param>
    ''' <param name="nBaseTempo">Integer che contiene l'intervallo massimo sul quale si devono calcolare gli importi<br />
    ''' (solitamente le tariffe sono calcolate su base annuale e quindi nBaseTempo sarà uguale a 365/366).</param>
    ''' <param name="sAnno">stringa anno di calcolo</param>
    ''' <param name="sOperatore">stringa operatore che esegue l'operazione</param>
    ''' <returns>oggetto di tipo ObjTotRuoloFatture contenente il ruolo calcolato con relativi documenti</returns>
    ''' <remarks></remarks>
    Public Function CreaRuoloH2O(ByVal ForzaQuotaFissa As Integer, ByVal nTipoCalcoloFattura As Integer, ByVal oListContatori() As objContatore, ByVal oMyTariffe As ObjTariffe, ByVal nBaseTempo As Integer, ByVal sAnno As String, ByVal sOperatore As String) As ObjTotRuoloFatture
        Try
            Dim x, y, z, nIdContribPrec As Integer
            Dim oMyTotRuoloH2O As New ObjTotRuoloFatture
            Dim oMyFattura As ObjFattura = Nothing
            Dim nList As Integer = -1
            Dim nContribuenti As Integer = 0
            Dim nDocumenti As Integer = 0
            Dim impPositivi As Double = 0
            Dim impNegativi As Double = 0
            Dim sMatricolaPrec As String = ""
            Dim nMyPeriodo, nMyConsumo, nMyGiorni, nMyLetPrec, nMyLetAtt As Integer
            Dim tMyDataLettPrec, tMyDataLetAtt As DateTime
            Dim oListAliquote() As oDettaglioAliquote
            Dim oListLettureFattura() As ObjLettura
            Dim oMyLettura As ObjLettura

            Log.Debug("ClsElaborazione::CreaRuoloH2O::inizio procedura")

            z = -1
            If Not oListContatori Is Nothing Then
                For x = 0 To oListContatori.GetUpperBound(0)
                    For y = 0 To oListContatori(x).oListLetture.GetUpperBound(0)
                        'il consumo del sub contatore lo tolgo solo una volta
                        If oListContatori(x).sMatricola = sMatricolaPrec Then
                            oListContatori(x).oListLetture(y).nConsumoSubContatore = 0
                        End If
                        'calcolo il consumo
                        If oListContatori(x).oListLetture(y).nConsumo = -1 Then
                            oListContatori(x).oListLetture(y).nConsumo = CalcolaConsumo(oListContatori(x).oListLetture(y).nLetturaPrec, oListContatori(x).oListLetture(y).nLetturaAtt, oListContatori(x).oListLetture(y).nConsumoSubContatore, oListContatori(x).nFondoScala)
                        End If
                        If oListContatori(x).oListLetture(y).nConsumo >= 0 Then
                            'calcolo i giorni
                            If oListContatori(x).oListLetture(y).nGiorni = -1 Then
                                oListContatori(x).oListLetture(y).nGiorni = CalcolaGiorni(oListContatori(x).oListLetture(y).tDataLetturaPrec, oListContatori(x).oListLetture(y).tDataLetturaAtt, nBaseTempo)
                            End If
                            If oListContatori(x).oListLetture(y).nGiorni = -1 Then
                                Log.Debug("Si è verificato un errore in ClsElaborazione::CreaRuoloH2O::giorni negativi per la matricola::" & oListContatori(x).sMatricola)
                                Return Nothing
                            End If
                            If IsNewDoc(nTipoCalcoloFattura, oListContatori(x), nIdContribPrec, sMatricolaPrec) = True Then
                                If Not IsNothing(oMyFattura) Then
                                    oMyFattura.nConsumo = nMyConsumo
                                    oMyFattura.nGiorni = nMyGiorni
                                    oMyFattura.nIdPeriodo = nMyPeriodo
                                    oMyFattura.nLetturaPrec = nMyLetPrec
                                    oMyFattura.nLetturaAtt = nMyLetAtt
                                    oMyFattura.tDataLetturaPrec = tMyDataLettPrec
                                    oMyFattura.tDataLetturaAtt = tMyDataLetAtt
                                    'memorizzo le letture associate alla fattura
                                    oMyFattura.oLetture = oListLettureFattura

                                    'calcolo il dettaglio iva
                                    If CalcoloDettaglioIva(oListContatori(x).sIdEnte, oListAliquote, sOperatore, oMyFattura) = 0 Then
                                        Return Nothing
                                    End If
                                    nList += 1
                                    ReDim Preserve oMyTotRuoloH2O.oFatture(nList)
                                    oMyTotRuoloH2O.oFatture(nList) = oMyFattura
                                    sAnno = ""
                                    nMyPeriodo = -1 : nMyConsumo = 0 : nMyGiorni = 0 : nMyLetPrec = 0 : nMyLetAtt = 0
                                    tMyDataLettPrec = Date.MinValue : tMyDataLetAtt = Date.MinValue
                                    z = -1
                                End If
                                'inizializzo la nuova fattura
                                oMyFattura = New ObjFattura
                                oListAliquote = Nothing
                                'valorizzo i dati della fattura
                                oMyFattura = ValDatiFattura(oListContatori(x), sAnno, nMyPeriodo, nMyConsumo, nMyGiorni, tMyDataLettPrec, nMyLetPrec, tMyDataLetAtt, nMyLetAtt, sOperatore)
                                If IsNothing(oMyFattura) Then
                                    Return Nothing
                                End If
                            End If
                            'calcolo gli importi della lettura
                            If CalcolaDovutoH2O(ForzaQuotaFissa, oListContatori(x), oMyTariffe, sOperatore, y, False, oMyFattura, oListAliquote) = 0 Then
                                Return Nothing
                            End If
                            'aggiorno i totalizzatori
                            If nIdContribPrec <> oMyFattura.nIdUtente Then
                                nContribuenti += 1
                            End If
                            nDocumenti += 1
                            If oMyFattura.impFattura >= 0 Then
                                impPositivi += FormatNumber(oMyFattura.impFattura, 2)
                            Else
                                impNegativi += FormatNumber(oMyFattura.impFattura, 2)
                            End If
                        End If
                        nIdContribPrec = oMyFattura.nIdUtente
                        sMatricolaPrec = oListContatori(x).sMatricola
                        nMyPeriodo = oListContatori(x).oListLetture(y).nIdPeriodo
                        nMyConsumo += oListContatori(x).oListLetture(y).nConsumo
                        nMyGiorni += oListContatori(x).oListLetture(y).nGiorni
                        If nMyLetPrec = 0 Then
                            nMyLetPrec = oListContatori(x).oListLetture(y).nLetturaPrec
                        End If
                        nMyLetAtt = oListContatori(x).oListLetture(y).nLetturaAtt
                        If tMyDataLettPrec = Date.MinValue Then
                            tMyDataLettPrec = oListContatori(x).oListLetture(y).tDataLetturaPrec
                        End If
                        tMyDataLetAtt = oListContatori(x).oListLetture(y).tDataLetturaAtt
                        'memorizzo le letture associate alla fattura
                        oMyLettura = New ObjLettura
                        oMyLettura.IdLettura = oListContatori(x).oListLetture(y).IdLettura
                        z += 1
                        ReDim Preserve oListLettureFattura(z)
                        oListLettureFattura(z) = oMyLettura
                    Next
                Next
                oMyFattura.nConsumo = nMyConsumo
                oMyFattura.nGiorni = nMyGiorni
                oMyFattura.nIdPeriodo = nMyPeriodo
                oMyFattura.nLetturaPrec = nMyLetPrec
                oMyFattura.nLetturaAtt = nMyLetAtt
                oMyFattura.tDataLetturaPrec = tMyDataLettPrec
                oMyFattura.tDataLetturaAtt = tMyDataLetAtt
                'memorizzo le letture associate alla fattura
                oMyFattura.oLetture = oListLettureFattura
                'calcolo il dettaglio iva
                If CalcoloDettaglioIva(oListContatori(x - 1).sIdEnte, oListAliquote, sOperatore, oMyFattura) = 0 Then
                    Return Nothing
                End If
                nList += 1
                ReDim Preserve oMyTotRuoloH2O.oFatture(nList)
                oMyTotRuoloH2O.oFatture(nList) = oMyFattura
                sAnno = ""
                nMyPeriodo = -1 : nMyConsumo = 0 : nMyGiorni = 0 : nMyLetPrec = 0 : nMyLetAtt = 0
                tMyDataLettPrec = Date.MinValue : tMyDataLetAtt = Date.MinValue
                z = -1
                'valorizzo i totalizzatori
                oMyTotRuoloH2O.sIdEnte = oListContatori(0).sIdEnte
                oMyTotRuoloH2O.nIdPeriodo = oListContatori(0).oListLetture(0).nIdPeriodo
            End If
            oMyTotRuoloH2O.tDataCalcoli = Now
            oMyTotRuoloH2O.nNContribuenti = nContribuenti
            oMyTotRuoloH2O.nNDocumenti = nDocumenti
            oMyTotRuoloH2O.impPositivi = impPositivi
            oMyTotRuoloH2O.impNegativi = impNegativi
            oMyTotRuoloH2O.sOperatore = sOperatore

            Log.Debug("ClsElaborazione::CreaRuoloH2O::fine procedura")
            Return oMyTotRuoloH2O
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::CreaRuoloH2O::" & Err.Message)
            Return Nothing
        End Try
    End Function

    Private Function ValDatiFattura(ByVal oMyContatore As objContatore, ByVal sAnno As String, ByVal nIdPeriodo As Integer, ByVal nConsumo As Integer, ByVal nGiorni As Integer, ByVal tDataLetPrec As DateTime, ByVal nLetPrec As Integer, ByVal tDataLetAtt As Date, ByVal nLetAtt As Integer, ByVal sOperatore As String) As ObjFattura
        Dim oMyFattura As New ObjFattura

        Try
            oMyFattura.sIdEnte = oMyContatore.sIdEnte
            oMyFattura.nIdPeriodo = nIdPeriodo
            'prelevo l’anagrafica
            oMyFattura.oAnagrafeUtente = oMyContatore.oAnagUtente
            oMyFattura.sTipoDocumento = "F"
            oMyFattura.sAnno = sAnno
            oMyFattura.nIdIntestatario = oMyContatore.nIdIntestatario
            oMyFattura.nIdUtente = oMyContatore.nIdUtente
            oMyFattura.sNUtente = oMyContatore.sNumeroUtente
            oMyFattura.sMatricola = oMyContatore.sMatricola
            oMyFattura.sViaContatore = oMyContatore.sUbicazione
            oMyFattura.sCivicoContatore = oMyContatore.sCivico
            oMyFattura.sFrazioneContatore = oMyContatore.sFrazione
            oMyFattura.nTipoContatore = oMyContatore.nTipoContatore
            oMyFattura.nUtenze = oMyContatore.nNumeroUtenze
            oMyFattura.nTipoUtenza = oMyContatore.nTipoUtenza
            oMyFattura.bEsenteAcqua = oMyContatore.bEsenteAcqua
            oMyFattura.nCodDepurazione = oMyContatore.nCodDepurazione
            oMyFattura.bEsenteDepurazione = oMyContatore.bEsenteDepurazione
            oMyFattura.nCodFognatura = oMyContatore.nCodFognatura
            oMyFattura.bEsenteFognatura = oMyContatore.bEsenteFognatura
            '*** 20121217 - calcolo quota fissa acqua+depurazione+fognatura ***
            oMyFattura.bEsenteAcquaQF = oMyContatore.bEsenteAcquaQF
            oMyFattura.bEsenteDepQF = oMyContatore.bEsenteDepQF
            oMyFattura.bEsenteFogQF = oMyContatore.bEsenteFogQF
            '*** ***
            oMyFattura.nConsumo = nConsumo
            oMyFattura.tDataLetturaPrec = tDataLetPrec
            oMyFattura.nLetturaPrec = nLetPrec
            oMyFattura.tDataLetturaAtt = tDataLetAtt
            oMyFattura.nLetturaAtt = nLetAtt
            oMyFattura.nGiorni = nGiorni
            oMyFattura.tDataInserimento = Now
            oMyFattura.sOperatore = sOperatore

            Return oMyFattura
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::ValDatiFattura::" & Err.Message)
            Return Nothing
        End Try
    End Function

    Private Function IsNewDoc(ByVal nTipoCalcoloFattura As Integer, ByVal oMyContatore As objContatore, ByVal nIdUtentePrec As Integer, ByVal sMatricolaPrec As String) As Boolean
        Try
            If nTipoCalcoloFattura = RemotingInterfaceMotoreH2O.RemotingInterfaceMotoreH2O.Util.FATTURA_PER_LETTURA Then
                Return True
            ElseIf nTipoCalcoloFattura = RemotingInterfaceMotoreH2O.RemotingInterfaceMotoreH2O.Util.FATTURA_PER_UTENTEMATRICOLA Then
                If oMyContatore.nIdUtente <> nIdUtentePrec Or oMyContatore.sMatricola <> sMatricolaPrec Then
                    Return True
                Else
                    Return False
                End If
            ElseIf nTipoCalcoloFattura = RemotingInterfaceMotoreH2O.RemotingInterfaceMotoreH2O.Util.FATTURA_PER_UTENTE Then
                If oMyContatore.nIdUtente <> nIdUtentePrec Then
                    Return True
                Else
                    Return False
                End If
            End If

            Return True
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::IsNewDoc::" & Err.Message)
            Throw New Exception
        End Try
    End Function

    ''' <summary>
    ''' In base alla lettura precedente e alla lettura attuale viene determinato il consumo.
    ''' </summary>
    ''' <param name="nLetturaPrec">Integer contenente la lettura precedente</param>
    ''' <param name="nLetturaAtt">Integer contenente la lettura attuale</param>
    ''' <returns>Integer contenente il consumo</returns>
    ''' <remarks>
    ''' </remarks>
    Public Function CalcolaConsumo(ByVal nLetturaPrec As Integer, ByVal nLetturaAtt As Integer, ByVal nConsumoSubContatore As Integer, ByVal nFondoScala As Integer) As Integer
        Dim culture As IFormatProvider
        culture = New System.Globalization.CultureInfo("it-IT", True)
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("it-IT")
        Try
            Dim nConsumo As Integer

            nConsumo = nLetturaAtt - nLetturaPrec - nConsumoSubContatore
            If nConsumo < 0 Then
                nConsumo = (nLetturaAtt + (nFondoScala - nLetturaPrec)) - nConsumoSubContatore
            End If

            Return nConsumo
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::CalcolaConsumo::" & Err.Message)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' In base alla data di lettura precedente e alla data di lettura attuale vengono determinati i giorni di consumo.<br />
    ''' Viene determinata l'unità di misura del tempo:<br />
    ''' - se nBaseTempo è uguale a 365 o 366 l'unità di misura è in giorni<br />
    ''' - se nBaseTempo è uguale a 12 l'unità di misura è in mesi<br />
    ''' </summary>
    ''' <param name="tDataPrecedente">Date contenente la data di lettura precedente</param>
    ''' <param name="tDataAttuale">Date contenente la data di lettura attuale</param>
    ''' <param name="nBaseTempo">Integer che contiene l'intervallo massimo sul quale si devono calcolare gli importi
    ''' (solitamente le tariffe sono calcolate su base annuale e quindi nBaseTempo sarà uguale a 365/366)</param>
    ''' <returns>Integer contenente il numero di giorni</returns>
    ''' <remarks>
    ''' </remarks>
    Public Function CalcolaGiorni(ByVal tDataPrecedente As Date, ByVal tDataAttuale As Date, ByVal nBaseTempo As Integer) As Integer
        Dim culture As IFormatProvider
        culture = New System.Globalization.CultureInfo("it-IT", True)
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("it-IT")
        Try
            Dim nGiorni As Integer
            Dim MyDateInterval As DateInterval
            If nBaseTempo = 365 Then
                MyDateInterval = DateInterval.Day
            Else
                MyDateInterval = DateInterval.Month
            End If
            Log.Debug("CalcoloGiorni::DateDiff(MyDateInterval, tDataPrecedente, tDataAttuale)::" & MyDateInterval.ToString() & "::" & tDataPrecedente.ToString() & "::" & tDataAttuale.ToString)
            nGiorni = DateDiff(MyDateInterval, tDataPrecedente, tDataAttuale)
            Return nGiorni
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::CalcolaGiorni::" & Err.Message)
            Return -1
        End Try
    End Function

    ''' <summary>
    ''' Calcola il dovuto in base ai parametri passati
    ''' L'oggetto objContatore contiene i dati del contatore e della lettura da calcolare (data lettura precedente, data lettura attuale, anagrafica, lettura precedente, lettura attuale, etc...).<br />
    ''' L'oggetto ObjTariffe contiene tutti i parametri per il calcolo delle fatture (configurazione scaglioni, canoni, addizionali, quote fisse,ecc...)<br />
    ''' La procedura in base al consumo e ai giorni determina gli importi delle tariffe configurate a Sistema:<br />
    ''' - scaglioni<br />
    ''' - canoni<br />
    ''' - addizionali<br />
    ''' - nolo<br />
    ''' - quota fissa<br />
    ''' - IVA<br />
    ''' </summary>
    ''' <param name="ForzaQuotaFissa">intero parametro di configurazione ambiente se 1 la quota fissa viene calcolata anche se contatore esente acqua</param>
    ''' <param name="oMyContatore">oggetto di tipo objContatore con i dati da calcolare</param>
    ''' <param name="oTariffe">oggetto di tipo ObjTariffe con le tariffe da utilizzare per il calcolo</param>
    ''' <param name="sOperatore">stringa operatore che esegue l'operazione</param>
    ''' <param name="bIsUnaTantum">booleano indica se deve essere applicato il nolo unatantum</param>
    ''' <param name="oFattura">out oggetto di tipo ObjFattura viene aggiornato con gli importi calcolati</param>
    ''' <returns>Integer restituisce 1 se è andato a buon fine altrimenti 0</returns>
    ''' <example>
    ''' Esempio di calcolo bolletta:
    ''' <para>
    ''' Dati Contatore:
    ''' </para>
    ''' Data Lettura Precedente = 01/01/2007	Lettura Precedente = 100<br />
    ''' Data Lettura Attuale = 30/06/2007	Lettura Attuale = 600<br />
    '''<br />
    ''' Consumo = 500	Giorni = 181<br />
    ''' Tipologia utenza = domestica<br />
    ''' Numero utenze = 2<br />
    ''' <para>
    ''' Tariffe<br />
    ''' Scaglioni Validi<br />
    ''' Da 1 Mc	a 200	0,150000 € /Mc	IVA al 10%<br />
    ''' Da 201 Mc	a 999999999	0,220000 €/Mc	IVA al 10%<br />
    ''' </para>
    ''' <para>
    ''' Canoni<br />
    ''' Depurazione	0,150000 € Mc	80% del Consumo	IVA al 10%<br />
    ''' Fognatura	0,330000 €/Mc	80% del Consumo	IVA al 10%<br />
    ''' </para>
    ''' <para>
    ''' Addizionali<br />
    ''' 0,90	Imposta di Bollo	IVA esente<br />
    ''' </para>
    ''' <para>
    ''' Quota Fissa<br />
    '''<br />
    ''' domestica 	Da 1 Mc	a 100 Mc	5,00 €<br />
    ''' domestica  	Da 101 Mc	a 200 Mc	7,00 €<br />
    ''' domestica 	Da 201 Mc	a 300 Mc	9,00 €<br />
    ''' domestica 	Da 301 Mc	a 400 Mc	10,00 €<br />
    ''' domestica 	Da 401 Mc	a 999 Mc	20,00 €<br />
    ''' <br />
    ''' Determinazione Importi Dovuti<br />
    ''' Consumo per utenza = 500/2 = 250<br />
    '''<br />
    ''' </para>
    ''' <para>
    ''' Scaglioni<br />
    ''' 200 Mc	0,150000 €/Mc	(((200 * 0,150000)*181)/365) *2 = 29,75 €<br />
    ''' 50 Mc	0,220000 €/Mc	(((50 * 0,220000)*181)/365) *2 = 10,91 €<br />
    '''<br />
    ''' Totale Scaglioni = 40,66 €<br />
    '''</para>
    ''' <para>
    ''' Canoni<br />
    ''' Depurazione	0,150000 € Mc 	80% Mc Consumo	(((500*80)/100)*0,150000)*181)/365)= 29,75 €<br />
    ''' Fognatura	0,330000 € Mc 	80% Mc Consumo	(((500*80)/100)*0,330000)*181)/365)= 65,46 €<br />
    '''<br />
    ''' Totale Canoni = 95,21 €<br />
    ''' </para>
    ''' <para>
    ''' Addizionali<br />
    ''' 0,90	Imposta di Bollo<br />
    '''<br />
    ''' Totale Addizionali = 0,90 €<br />
    ''' </para>
    ''' <para>
    ''' Quota Fissa<br />
    ''' Da 401 Mc	a 999 Mc	20,00 €<br />
    '''<br />
    ''' Totale Quota Fissa = 20,00 €<br />
    ''' </para>
    ''' <para>
    ''' Totale Imponibile al 10% = 40,66 € + 95,21 € + 20,00 € = 155,87 €<br />
    ''' Totale Imponibile IVA esente = 0,90 €<br />
    ''' Totale IVA al 10% = 15,59 €<br />
    ''' Totale = 155,87 € + 0,90 € + 15,59 € = 172,36 €<br />
    ''' Totale Fattura = 172,36 € <br />
    ''' </para>
    '''</example>
    ''' <remarks></remarks>
    Public Function CalcolaDovutoH2O(ByVal ForzaQuotaFissa As Integer, ByVal oMyContatore As objContatore, ByVal oTariffe As ObjTariffe, ByVal sOperatore As String, ByVal nLetturaCalcolo As Integer, ByVal bIsUnaTantum As Boolean, ByRef oFattura As ObjFattura, ByRef oListAliquote() As oDettaglioAliquote) As Integer
        Try 'aliquota iva fissa e unica
            Dim nBaseTempo As Integer = System.Configuration.ConfigurationSettings.AppSettings("BaseTempo")

            'calcolo gli scaglioni
            If CalcoloScaglioni(oMyContatore, oTariffe.oScaglioni, nBaseTempo, sOperatore, nLetturaCalcolo, oFattura, oListAliquote) = 0 Then
                Return 0
            End If
            'calcolo i Canoni
            If CalcoloCanoni(oMyContatore, oTariffe, nBaseTempo, sOperatore, nLetturaCalcolo, oFattura, oListAliquote) = 0 Then
                Return 0
            End If
            'calcolo le Addizionali
            If CalcoloAddizionali(oMyContatore.sIdEnte, oMyContatore.oListLetture(nLetturaCalcolo).IdLettura, oTariffe, sOperatore, oFattura, oListAliquote) = 0 Then
                Return 0
            End If
            'calcolo i nolo
            If CalcoloNolo(oMyContatore, oTariffe, nBaseTempo, sOperatore, nLetturaCalcolo, bIsUnaTantum, oFattura, oListAliquote) = 0 Then
                Return 0
            End If
            'calcolo le Quote Fisse
            If CalcoloQuoteFisse(ForzaQuotaFissa, oMyContatore, oTariffe, nBaseTempo, sOperatore, nLetturaCalcolo, oFattura, oListAliquote) = 0 Then
                Return 0
            End If
            Return 1
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::CalcolaDovutoH2O::" & Err.Message)
            Return 0
        End Try
    End Function

    Public Function CalcolaDovutoH2O(ByVal ForzaQuotaFissa As Integer, ByVal oMyContatore As objContatore, ByVal oTariffe As ObjTariffe, ByVal sOperatore As String, ByVal nLetturaCalcolo As Integer, ByVal bIsUnaTantum As Boolean, ByRef oFattura As ObjFattura) As Integer
        Try 'aliquota iva fissa e unica
            Dim nBaseTempo As Integer = System.Configuration.ConfigurationSettings.AppSettings("BaseTempo")
            Dim oListAliquote() As oDettaglioAliquote

            'calcolo gli scaglioni
            If CalcoloScaglioni(oMyContatore, oTariffe.oScaglioni, nBaseTempo, sOperatore, nLetturaCalcolo, oFattura, oListAliquote) = 0 Then
                Return 0
            End If
            'calcolo i Canoni
            If CalcoloCanoni(oMyContatore, oTariffe, nBaseTempo, sOperatore, nLetturaCalcolo, oFattura, oListAliquote) = 0 Then
                Return 0
            End If
            'calcolo le Addizionali
            If CalcoloAddizionali(oMyContatore.sIdEnte, oMyContatore.oListLetture(nLetturaCalcolo).IdLettura, oTariffe, sOperatore, oFattura, oListAliquote) = 0 Then
                Return 0
            End If
            'calcolo i nolo
            If CalcoloNolo(oMyContatore, oTariffe, nBaseTempo, sOperatore, nLetturaCalcolo, bIsUnaTantum, oFattura, oListAliquote) = 0 Then
                Return 0
            End If
            'calcolo le Quote Fisse
            If CalcoloQuoteFisse(ForzaQuotaFissa, oMyContatore, oTariffe, nBaseTempo, sOperatore, nLetturaCalcolo, oFattura, oListAliquote) = 0 Then
                Return 0
            End If
            'calcolo il dettaglio iva
            If CalcoloDettaglioIva(oMyContatore.sIdEnte, oListAliquote, sOperatore, oFattura) = 0 Then
                Return 0
            End If
            Return 1
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::CalcolaDovutoH2O::" & Err.Message)
            Return 0
        End Try
    End Function

#Region "Blocco Calcoli"
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="oMyContatore"></param>
    ''' <param name="oMyTariffe"></param>
    ''' <param name="nMyBaseTempo"></param>
    ''' <param name="sOperatore"></param>
    ''' <param name="nLetturaCalcolo"></param>
    ''' <param name="oMyFattura"></param>
    ''' <param name="oMyListAliquote"></param>
    ''' <returns></returns>
    ''' <revisionHistory>
    ''' <revision date="19/11/2010">rapporto gli scaglioni al numero di utenze in questo modo non "sporco" il consumo con gli arrotondamenti</revision>
    ''' <revision date="13/02/2020">rapporto gli scaglioni oltre che ai giorni anche al numero di utenze; in questo modo non devo ricalcolare il consumo</revision>
    ''' </revisionHistory>
    Private Function CalcoloScaglioni(ByVal oMyContatore As objContatore, ByVal oMyTariffe As OggettoScaglione(), ByVal nMyBaseTempo As Integer, ByVal sOperatore As String, ByVal nLetturaCalcolo As Integer, ByRef oMyFattura As ObjFattura, ByRef oMyListAliquote() As oDettaglioAliquote) As Integer
        Dim oScaglioniSuGGConsumo() As OggettoScaglione
        Dim oScaglione As ObjTariffeScaglione
        Dim oListScaglioni() As ObjTariffeScaglione
        Dim nList As Integer = -1
        Dim nConsumoDa, y As Integer
        Dim nConsumoTot, nConsumoApplicato, nConsumoCalcolo As Double
        Dim impDovuto As Double = 0

        Try
            'controllo se ho già degli scaglioni sulla fattura
            Log.Debug("ClsElaborazione.CalcoloScaglioni.sMatricola->" + oMyFattura.sMatricola)
            If Not IsNothing(oMyFattura.oScaglioni) Then
                oListScaglioni = oMyFattura.oScaglioni
                nList = oListScaglioni.GetUpperBound(0)
            End If
            If oMyContatore.bEsenteAcqua = False Then
                For y = nLetturaCalcolo To nLetturaCalcolo 'oMyContatore.oListLetture.GetUpperBound(0)
                    'rapporto gli scaglioni ai giorni di consumo e alle utenze
                    oScaglioniSuGGConsumo = GetScaglioniSuGGConsumo(nMyBaseTempo, oMyContatore.oListLetture(y).nGiorni, oMyContatore.nNumeroUtenze, oMyTariffe)
                    If oScaglioniSuGGConsumo Is Nothing Then
                        Return 0
                    End If

                    nConsumoTot = oMyContatore.oListLetture(y).nConsumo
                    Log.Debug("ClsElaborazione.CalcoloScaglioni.nConsumoTot->" + nConsumoTot.ToString)
                    nConsumoApplicato = 0 : nConsumoDa = 1
                    If Not oMyTariffe Is Nothing Then
                        For Each myScaglione As OggettoScaglione In oScaglioniSuGGConsumo
                            nConsumoCalcolo = GetConsumoCalcolo(nConsumoTot, nConsumoDa, oMyContatore.nTipoUtenza, myScaglione)
                            Log.Debug("ClsElaborazione.CalcoloScaglioni.nConsumoTot->" + nConsumoTot.ToString + ", nConsumoDa->" + nConsumoDa.ToString + ", nConsumoCalcolo->" + nConsumoCalcolo.ToString)
                            If nConsumoCalcolo > 0 Then
                                'se lavoro con base giorni devo considerare l'anno bisestile
                                If nMyBaseTempo <> 12 Then
                                    If Date.IsLeapYear(CInt(myScaglione.sAnno)) = True Then
                                        nMyBaseTempo = 366
                                    Else
                                        nMyBaseTempo = 365
                                    End If
                                End If
                                'calcolo il dovuto
                                impDovuto = (nConsumoCalcolo * myScaglione.dTariffa)
                                Log.Debug("ClsElaborazione.CalcoloScaglioni.nConsumoCalcolo->" + nConsumoCalcolo.ToString + ",dTariffa->" + myScaglione.dTariffa.ToString + ",impDovuto->" + impDovuto.ToString)
                                If impDovuto < myScaglione.dMinimo Then
                                    impDovuto = myScaglione.dMinimo
                                End If
                                'creo il nuovo oggetto dovuto scaglione
                                oScaglione = New ObjTariffeScaglione
                                oScaglione.Id = -1
                                oScaglione.nIdFattura = -1
                                oScaglione.nIdLettura = oMyContatore.oListLetture(nLetturaCalcolo).IdLettura
                                oScaglione.sIdEnte = oMyContatore.sIdEnte
                                oScaglione.sAnno = myScaglione.sAnno
                                oScaglione.nIdScaglione = myScaglione.ID
                                oScaglione.nAliquota = myScaglione.dAliquota
                                oScaglione.nQuantita = nConsumoCalcolo
                                oScaglione.impScaglione = impDovuto
                                oScaglione.tDataInserimento = Now
                                oScaglione.sOperatore = sOperatore
                                'aggiorno l'array per il dettaglio iva
                                If CalcolaDettaglioIva(oScaglione.nAliquota, impDovuto, oMyListAliquote) = 0 Then
                                    Return 0
                                End If
                                'aggiorno i totalizzatori
                                oMyFattura.impScaglioni += FormatNumber(impDovuto, 2)
                                If oScaglione.nAliquota = 0 Then
                                    oMyFattura.impEsente += FormatNumber(oScaglione.impScaglione, 2)
                                Else
                                    oMyFattura.impImponibile += FormatNumber(oScaglione.impScaglione, 2)
                                End If
                                'aggiorno il consumo da utilizzare
                                nConsumoApplicato += nConsumoCalcolo
                                nConsumoDa = nConsumoApplicato + 1
                                'aggiorno l'array
                                nList += 1
                                ReDim Preserve oListScaglioni(nList)
                                oListScaglioni(nList) = oScaglione
                            End If
                        Next
                        oMyFattura.oScaglioni = oListScaglioni
                    End If
                Next
            End If
            Return 1
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::CalcoloScaglioni::" & Err.Message)
            Return 0
        End Try
    End Function
    'Private Function CalcoloScaglioni(ByVal oMyContatore As objContatore, ByVal oMyTariffe As OggettoScaglione(), ByVal nMyBaseTempo As Integer, ByVal sOperatore As String, ByVal nLetturaCalcolo As Integer, ByRef oMyFattura As ObjFattura, ByRef oMyListAliquote() As oDettaglioAliquote) As Integer
    '    Dim oScaglioniSuGGConsumo() As OggettoScaglione
    '    Dim oScaglione As ObjTariffeScaglione
    '    Dim oListScaglioni() As ObjTariffeScaglione
    '    Dim nList As Integer = -1
    '    Dim nConsumoDa, x, y As Integer
    '    Dim nConsumoTot, nConsumoApplicato, nConsumoCalcolo As Double
    '    Dim impDovuto As Double = 0

    '    Try
    '        'controllo se ho già degli scaglioni sulla fattura
    '        If Not IsNothing(oMyFattura.oScaglioni) Then
    '            oListScaglioni = oMyFattura.oScaglioni
    '            nList = oListScaglioni.GetUpperBound(0)
    '        End If
    '        If oMyContatore.bEsenteAcqua = False Then
    '            For y = nLetturaCalcolo To nLetturaCalcolo 'oMyContatore.oListLetture.GetUpperBound(0)
    '                'rapporto gli scaglioni ai giorni di consumo
    '                oScaglioniSuGGConsumo = GetScaglioniSuGGConsumo(nMyBaseTempo, oMyContatore.oListLetture(y).nGiorni, oMyContatore.nNumeroUtenze, oMyTariffe)
    '                If oScaglioniSuGGConsumo Is Nothing Then
    '                    Return 0
    '                End If

    '                nConsumoTot = GetConsumo(oMyContatore.oListLetture(y).nConsumo, oMyContatore.nNumeroUtenze, oMyContatore.oListLetture(y).nTipoArrotondConsumo)
    '                nConsumoApplicato = 0 : nConsumoDa = 1
    '                If Not oMyTariffe Is Nothing Then
    '                    For x = 0 To oMyTariffe.GetUpperBound(0)
    '                        nConsumoCalcolo = GetConsumoCalcolo(nConsumoTot, nConsumoDa, oMyContatore.nTipoUtenza, oMyTariffe(x))
    '                        If nConsumoCalcolo > 0 Then
    '                            'se lavoro con base giorni devo considerare l'anno bisestile
    '                            If nMyBaseTempo <> 12 Then
    '                                If Date.IsLeapYear(CInt(oMyTariffe(x).sAnno)) = True Then
    '                                    nMyBaseTempo = 366
    '                                Else
    '                                    nMyBaseTempo = 365
    '                                End If
    '                            End If
    '                            'calcolo il dovuto
    '                            '*** 20101119 - rapporto gli scaglioni al numero di utenze in questo modo non "sporco" il consumo con gli arrotondamenti ***
    '                            'rapporto già gli scaglioni al tempo non devo + rapportare il calcolo del consumo
    '                            'impDovuto = (((nConsumoCalcolo * oMyTariffe.oScaglioni(x).dTariffa) * oMyContatore.nGiorni) / nMyBaseTempo) * oMyContatore.nUtenze
    '                            impDovuto = ((nConsumoCalcolo * oMyTariffe(x).dTariffa) * oMyContatore.nNumeroUtenze)
    '                            'impDovuto = (nConsumoCalcolo * oMyTariffe(x).dTariffa)
    '                            If impDovuto < oMyTariffe(x).dMinimo Then
    '                                impDovuto = oMyTariffe(x).dMinimo
    '                            End If
    '                            'creo il nuovo oggetto dovuto scaglione
    '                            oScaglione = New ObjTariffeScaglione
    '                            oScaglione.Id = -1
    '                            oScaglione.nIdFattura = -1
    '                            oScaglione.nIdLettura = oMyContatore.oListLetture(nLetturaCalcolo).IdLettura
    '                            oScaglione.sIdEnte = oMyContatore.sIdEnte
    '                            oScaglione.sAnno = oMyTariffe(x).sAnno
    '                            oScaglione.nIdScaglione = oMyTariffe(x).ID
    '                            oScaglione.nAliquota = oMyTariffe(x).dAliquota
    '                            '*** 20101119 - rapporto gli scaglioni al numero di utenze in questo modo non "sporco" il consumo con gli arrotondamenti ***
    '                            oScaglione.nQuantita = nConsumoCalcolo * oMyContatore.nNumeroUtenze
    '                            'oScaglione.nQuantita = nConsumoCalcolo
    '                            oScaglione.impScaglione = impDovuto
    '                            oScaglione.tDataInserimento = Now
    '                            oScaglione.sOperatore = sOperatore
    '                            'aggiorno l'array per il dettaglio iva
    '                            If CalcolaDettaglioIva(oScaglione.nAliquota, impDovuto, oMyListAliquote) = 0 Then
    '                                Return 0
    '                            End If
    '                            'aggiorno i totalizzatori
    '                            oMyFattura.impScaglioni += FormatNumber(impDovuto, 2)
    '                            If oScaglione.nAliquota = 0 Then
    '                                oMyFattura.impEsente += FormatNumber(oScaglione.impScaglione, 2)
    '                            Else
    '                                oMyFattura.impImponibile += FormatNumber(oScaglione.impScaglione, 2)
    '                            End If
    '                            'aggiorno il consumo da utilizzare
    '                            nConsumoApplicato += nConsumoCalcolo
    '                            nConsumoDa = nConsumoApplicato + 1
    '                            'aggiorno l'array
    '                            nList += 1
    '                            ReDim Preserve oListScaglioni(nList)
    '                            oListScaglioni(nList) = oScaglione
    '                        End If
    '                    Next
    '                    oMyFattura.oScaglioni = oListScaglioni
    '                End If
    '            Next
    '        End If
    '        Return 1
    '    Catch Err As Exception
    '        Log.Debug("Si è verificato un errore in ClsElaborazione::CalcoloScaglioni::" & Err.Message)
    '        Return 0
    '    End Try
    'End Function
    ''' <summary>
    ''' Calcolo il dovuto per ogni canone in base alla formula<br></br>
    ''' Dovuto = (((Consumo * PercentualeSuConsumo) / 100) * Tariffa)
    ''' i canoni vengono calcolati solo se il contatore non è esente dal servizio associato al canone
    ''' </summary>
    ''' <param name="oMyContatore">oggetto di tipo objContatore contiente i dati da usare per il calcolo</param>
    ''' <param name="oMyTariffe">oggetto di tipo ObjTariffe contiene le tariffe da usare per il calcolo</param>
    ''' <param name="nMyBaseTempo">intero indica l'intervallo di tempo da utilizzare per il calcolo</param>
    ''' <param name="sOperatore">stringa operatore che esegue l'operazione</param>
    ''' <param name="nLetturaCalcolo">intero indica la posizione della lista di letture che si sta analizzando</param>
    ''' <param name="oMyFattura">out oggetto di tipo ObjFattura viene aggiornato con gli importi calcolati</param>
    ''' <param name="oMyListAliquote">out lista di oggetti di tipo oDettaglioAliquote viene aggiornato con gli importi imponibile,iva ed esente calcolati</param>
    ''' <returns>intero 1 se andato a buon fine altrimenti 0</returns>
    ''' <remarks>i canoni non devono essere rapportati ai giorni perchè sono a consumo</remarks>
    Private Function CalcoloCanoni(ByVal oMyContatore As objContatore, ByVal oMyTariffe As ObjTariffe, ByVal nMyBaseTempo As Integer, ByVal sOperatore As String, ByVal nLetturaCalcolo As Integer, ByRef oMyFattura As ObjFattura, ByRef oMyListAliquote() As oDettaglioAliquote) As Integer
        Dim oCanone As ObjTariffeCanone
        Dim oListCanoni() As ObjTariffeCanone
        Dim nList As Integer = -1
        Dim x, y As Integer
        Dim impDovuto As Double = 0
        Dim bCalcola As Boolean

        Try
            'controllo se ho già dei canoni sulla fattura
            If Not IsNothing(oMyFattura.oCanoni) Then
                oListCanoni = oMyFattura.oCanoni
                nList = oListCanoni.GetUpperBound(0)
            End If
            If Not oMyTariffe.oCanoni Is Nothing Then
                For x = 0 To oMyTariffe.oCanoni.GetUpperBound(0)
                    bCalcola = False
                    For y = nLetturaCalcolo To nLetturaCalcolo  'oMyContatore.oListLetture.GetUpperBound(0)
                        If oMyContatore.nTipoUtenza = oMyTariffe.oCanoni(x).idTipoUtenza And oMyContatore.oListLetture(y).nConsumo > 0 Then
                            '*** 20141125 - Componente aggiuntiva sui consumi ***
                            'If oMyContatore.bEsenteDepurazione = False And oMyTariffe.oCanoni(x).idTipoCanone = OggettoCanone.Canone_Depurazione Then
                            '    bCalcola = True
                            'ElseIf oMyContatore.bEsenteFognatura = False And oMyTariffe.oCanoni(x).idTipoCanone = OggettoCanone.Canone_Fognatura Then
                            '    bCalcola = True
                            'End If
                            If oMyContatore.bEsenteAcqua = False And oMyTariffe.oCanoni(x).idServizio = OggettoCanone.Canone_H2O Then
                                bCalcola = True
                            ElseIf oMyContatore.bEsenteDepurazione = False And oMyTariffe.oCanoni(x).idServizio = OggettoCanone.Canone_Depurazione Then
                                bCalcola = True
                            ElseIf oMyContatore.bEsenteFognatura = False And oMyTariffe.oCanoni(x).idServizio = OggettoCanone.Canone_Fognatura Then
                                bCalcola = True
                            End If
                            '*** ***
                            If bCalcola = True Then
                                'se lavoro con base giorni devo considerare l'anno bisestile
                                If nMyBaseTempo <> 12 Then
                                    If Date.IsLeapYear(CInt(oMyTariffe.oCanoni(x).sAnno)) = True Then
                                        nMyBaseTempo = 366
                                    Else
                                        nMyBaseTempo = 365
                                    End If
                                End If
                                'calcolo il dovuto
                                '***20100305 - i canoni non devono essere rapportati ai giorni perchè sono a consumo ***
                                'impDovuto = ((((oMyContatore.nConsumo * oMyTariffe.oCanoni(x).dPercentualeSuConsumo) / 100) * oMyTariffe.oCanoni(x).dTariffa) * oMyContatore.nGiorni) / nMyBaseTempo
                                impDovuto = (((oMyContatore.oListLetture(y).nConsumo * oMyTariffe.oCanoni(x).dPercentualeSuConsumo) / 100) * oMyTariffe.oCanoni(x).dTariffa)
                                'creo il nuovo oggetto dovuto canone
                                oCanone = New ObjTariffeCanone
                                oCanone.Id = -1
                                oCanone.nIdFattura = -1
                                oCanone.nIdLettura = oMyContatore.oListLetture(nLetturaCalcolo).IdLettura
                                oCanone.sIdEnte = oMyContatore.sIdEnte
                                oCanone.sAnno = oMyTariffe.oCanoni(x).sAnno
                                oCanone.nIdCanone = oMyTariffe.oCanoni(x).ID
                                oCanone.nAliquota = oMyTariffe.oCanoni(x).dAliquota
                                oCanone.impCanone = impDovuto
                                oCanone.tDataInserimento = Now
                                oCanone.sOperatore = sOperatore
                                '*** 20141125 - Componente aggiuntiva sui consumi ***
                                oCanone.idServizio = oMyTariffe.oCanoni(x).idServizio
                                '*** ***
                                'aggiorno l'array per il dettaglio iva
                                If CalcolaDettaglioIva(oCanone.nAliquota, impDovuto, oMyListAliquote) = 0 Then
                                    Return 0
                                End If
                                'aggiorno i totalizzatori
                                oMyFattura.impCanoni += FormatNumber(impDovuto, 2)
                                If oCanone.nAliquota = 0 Then
                                    oMyFattura.impEsente += FormatNumber(oCanone.impCanone, 2)
                                Else
                                    oMyFattura.impImponibile += FormatNumber(oCanone.impCanone, 2)
                                End If
                                'aggiorno l'array
                                nList += 1
                                ReDim Preserve oListCanoni(nList)
                                oListCanoni(nList) = oCanone
                            End If
                        End If
                    Next
                Next
                oMyFattura.oCanoni = oListCanoni
            End If
            Return 1
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::CalcoloCanoni::" & Err.Message)
            Return 0
        End Try
    End Function

    Private Function CalcoloAddizionali(ByVal sIdEnte As String, ByVal IdLettura As Integer, ByVal oMyTariffe As ObjTariffe, ByVal sOperatore As String, ByRef oMyFattura As ObjFattura, ByRef oMyListAliquote() As oDettaglioAliquote) As Integer
        Dim oAddizionale As ObjTariffeAddizionale
        Dim oListAddizionali() As ObjTariffeAddizionale
        Dim nList As Integer = -1
        Dim x As Integer
        Dim impDovuto As Double = 0

        Try
            'controllo se ho già delle addizionali sulla fattura
            If Not IsNothing(oMyFattura.oAddizionali) Then
                oListAddizionali = oMyFattura.oAddizionali
                nList = oListAddizionali.GetUpperBound(0)
            End If
            If Not oMyTariffe.oAddizionali Is Nothing Then
                For x = 0 To oMyTariffe.oAddizionali.GetUpperBound(0)
                    'calcolo il dovuto
                    impDovuto = oMyTariffe.oAddizionali(x).dImporto
                    'creo il nuovo oggetto dovuto addizionale
                    oAddizionale = New ObjTariffeAddizionale
                    oAddizionale.Id = -1
                    oAddizionale.nIdFattura = -1
                    oAddizionale.nIdLettura = IdLettura
                    oAddizionale.sIdEnte = sIdEnte
                    oAddizionale.sAnno = oMyTariffe.oAddizionali(x).sAnno
                    oAddizionale.nIdAddizionale = oMyTariffe.oAddizionali(x).ID
                    oAddizionale.nAliquota = oMyTariffe.oAddizionali(x).Aliquota
                    oAddizionale.impAddizionale = impDovuto
                    '*** 20141117 - voce di costo specifica per utente ***
                    oAddizionale.sDescrizione = oMyTariffe.oAddizionali(x).sDescrizione
                    '*** ***
                    oAddizionale.tDataInserimento = Now
                    oAddizionale.sOperatore = sOperatore
                    'aggiorno l'array per il dettaglio iva
                    If CalcolaDettaglioIva(oAddizionale.nAliquota, impDovuto, oMyListAliquote) = 0 Then
                        Return 0
                    End If
                    'aggiorno i totalizzatori
                    oMyFattura.impAddizionali += FormatNumber(impDovuto, 2)
                    If oAddizionale.nAliquota = 0 Then
                        oMyFattura.impEsente += FormatNumber(oAddizionale.impAddizionale, 2)
                    Else
                        oMyFattura.impImponibile += FormatNumber(oAddizionale.impAddizionale, 2)
                    End If
                    'aggiorno l'array
                    nList += 1
                    ReDim Preserve oListAddizionali(nList)
                    oListAddizionali(nList) = oAddizionale
                Next
                oMyFattura.oAddizionali = oListAddizionali
            End If
            Return 1
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::CalcoloAddizionali::" & Err.Message)
            Return 0
        End Try
    End Function

    Private Function CalcoloNolo(ByVal oMyContatore As objContatore, ByVal oMyTariffe As ObjTariffe, ByVal nMyBaseTempo As Integer, ByVal sOperatore As String, ByVal nLetturaCalcolo As Integer, ByVal bIsUnaTantum As Boolean, ByRef oMyFattura As ObjFattura, ByRef oMyListAliquote() As oDettaglioAliquote) As Integer
        Dim oNolo As ObjTariffeNolo
        Dim oListNoli() As ObjTariffeNolo
        Dim nList As Integer = -1
        Dim x, y As Integer
        Dim impDovuto As Double = 0

        Try
            'controllo se ho già dei noli sulla fattura
            If Not IsNothing(oMyFattura.oNolo) Then
                oListNoli = oMyFattura.oNolo
                nList = oListNoli.GetUpperBound(0)
            End If
            If Not oMyTariffe.oNolo Is Nothing Then
                For x = 0 To oMyTariffe.oNolo.GetUpperBound(0)
                    For y = nLetturaCalcolo To nLetturaCalcolo  'oMyContatore.oListLetture.GetUpperBound(0)
                        If (oMyTariffe.oNolo(x).bIsUnaTantum = True And bIsUnaTantum = True) Or (oMyTariffe.oNolo(x).bIsUnaTantum = False) Then
                            If oMyContatore.nTipoContatore = oMyTariffe.oNolo(x).idTipoContatore Then
                                'se lavoro con base giorni devo considerare l'anno bisestile
                                If nMyBaseTempo <> 12 Then
                                    If Date.IsLeapYear(CInt(oMyTariffe.oNolo(x).sAnno)) = True Then
                                        nMyBaseTempo = 366
                                    Else
                                        nMyBaseTempo = 365
                                    End If
                                End If
                                'calcolo il dovuto
                                If oMyTariffe.oNolo(x).bIsUnaTantum = True Then
                                    impDovuto = oMyTariffe.oNolo(x).dImporto
                                Else
                                    impDovuto = (oMyTariffe.oNolo(x).dImporto * oMyContatore.oListLetture(y).nGiorni) / nMyBaseTempo
                                End If
                                'creo il nuovo oggetto dovuto nolo
                                oNolo = New ObjTariffeNolo
                                oNolo.Id = -1
                                oNolo.nIdFattura = -1
                                oNolo.nIdLettura = oMyContatore.oListLetture(nLetturaCalcolo).IdLettura
                                oNolo.sIdEnte = oMyContatore.sIdEnte
                                oNolo.sAnno = oMyTariffe.oNolo(x).sAnno
                                oNolo.nIdNolo = oMyTariffe.oNolo(x).ID
                                oNolo.nAliquota = oMyTariffe.oNolo(x).dAliquota
                                oNolo.impNolo = impDovuto
                                oNolo.tDataInserimento = Now
                                oNolo.sOperatore = sOperatore
                                'aggiorno l'array per il dettaglio iva
                                If CalcolaDettaglioIva(oNolo.nAliquota, impDovuto, oMyListAliquote) = 0 Then
                                    Return 0
                                End If
                                'aggiorno i totalizzatori
                                oMyFattura.impNolo += FormatNumber(impDovuto, 2)
                                If oNolo.nAliquota = 0 Then
                                    oMyFattura.impEsente += FormatNumber(oNolo.impNolo, 2)
                                Else
                                    oMyFattura.impImponibile += FormatNumber(oNolo.impNolo, 2)
                                End If
                                'aggiorno l'array
                                nList += 1
                                ReDim Preserve oListNoli(nList)
                                oListNoli(nList) = oNolo
                            End If
                        End If
                    Next
                Next
                oMyFattura.oNolo = oListNoli
            End If
            Return 1
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::CalcoloNolo::" & Err.Message)
            Return 0
        End Try
    End Function

    Private Function CalcoloQuoteFisse(ByVal ForzaQuotaFissa As Integer, ByVal oMyContatore As objContatore, ByVal oMyTariffe As ObjTariffe, ByVal nMyBaseTempo As Integer, ByVal sOperatore As String, ByVal nLetturaCalcolo As Integer, ByRef oMyFattura As ObjFattura, ByRef oMyListAliquote() As oDettaglioAliquote) As Integer
        Dim oQuotaFissa As ObjTariffeQuotaFissa
        Dim oListQuoteFisse() As ObjTariffeQuotaFissa
        Dim nList As Integer = -1
        Dim x, y As Integer
        Dim impDovuto As Double = 0
        Dim nConsumoCalcolo As Double

        Try
            'controllo se ho già delle quote fisse sulla fattura
            If Not IsNothing(oMyFattura.oQuoteFisse) Then
                oListQuoteFisse = oMyFattura.oQuoteFisse
                nList = oListQuoteFisse.GetUpperBound(0)
            End If
            If ForzaQuotaFissa = 1 Then
                oMyContatore.bEsenteAcqua = False
            End If
            If Not oMyTariffe.oQuoteFisse Is Nothing Then
                For y = nLetturaCalcolo To nLetturaCalcolo            'oMyContatore.oListLetture.GetUpperBound(0)
                    nConsumoCalcolo = oMyContatore.oListLetture(y).nConsumo
                    If nConsumoCalcolo = 0 Then
                        nConsumoCalcolo = 1
                    End If
                    For x = 0 To oMyTariffe.oQuoteFisse.GetUpperBound(0)
                        If (nConsumoCalcolo <= oMyTariffe.oQuoteFisse(x).A And oMyContatore.nTipoUtenza = oMyTariffe.oQuoteFisse(x).idTipoUtenza) Then
                            'se lavoro con base giorni devo considerare l'anno bisestile
                            If nMyBaseTempo <> 12 Then
                                If Date.IsLeapYear(CInt(oMyTariffe.oQuoteFisse(x).sAnno)) = True Then
                                    nMyBaseTempo = 366
                                Else
                                    nMyBaseTempo = 365
                                End If
                            End If
                            'calcolo il dovuto
                            '*** 20121217 - calcolo quota fissa acqua+depurazione+fognatura ***
                            If oMyContatore.bEsenteAcquaQF = False Then
                                '***20100305 - la quota fissa deve essere rapportata ai giorni solo se da configurazione è stata impostata così***
                                If oMyTariffe.oQuoteFisse(x).bIsAGiorni = True Then
                                    '***20100203 - la quota fissa deve essere moltiplicata per il numero di utenze***
                                    impDovuto = ((oMyTariffe.oQuoteFisse(x).dImportoH2O * oMyContatore.oListLetture(y).nGiorni) / nMyBaseTempo) * oMyContatore.nNumeroUtenze
                                Else
                                    impDovuto = oMyTariffe.oQuoteFisse(x).dImportoH2O * oMyContatore.nNumeroUtenze
                                End If
                                'creo il nuovo oggetto dovuto scaglione
                                oQuotaFissa = New ObjTariffeQuotaFissa
                                oQuotaFissa.Id = -1
                                oQuotaFissa.nIdFattura = -1
                                oQuotaFissa.nIdLettura = oMyContatore.oListLetture(nLetturaCalcolo).IdLettura
                                oQuotaFissa.sIdEnte = oMyContatore.sIdEnte
                                oQuotaFissa.sAnno = oMyTariffe.oQuoteFisse(x).sAnno
                                oQuotaFissa.nIdQuotaFissa = oMyTariffe.oQuoteFisse(x).ID
                                oQuotaFissa.nAliquota = oMyTariffe.oQuoteFisse(x).dAliquota
                                oQuotaFissa.impQuotaFissa = impDovuto
                                oQuotaFissa.nIdTipoCanone = OggettoCanone.Canone_H2O
                                oQuotaFissa.tDataInserimento = Now
                                oQuotaFissa.sOperatore = sOperatore
                                'aggiorno l'array per il dettaglio iva
                                If CalcolaDettaglioIva(oQuotaFissa.nAliquota, impDovuto, oMyListAliquote) = 0 Then
                                    Return 0
                                End If
                                'aggiorno i totalizzatori
                                oMyFattura.impQuoteFisse += FormatNumber(impDovuto, 2)
                                If oQuotaFissa.nAliquota = 0 Then
                                    oMyFattura.impEsente += FormatNumber(oQuotaFissa.impQuotaFissa, 2)
                                Else
                                    oMyFattura.impImponibile += FormatNumber(oQuotaFissa.impQuotaFissa, 2)
                                End If
                                'aggiorno l'array
                                nList += 1
                                ReDim Preserve oListQuoteFisse(nList)
                                oListQuoteFisse(nList) = oQuotaFissa
                            End If
                            If oMyContatore.bEsenteDepQF = False Then
                                '***20100305 - la quota fissa deve essere rapportata ai giorni solo se da configurazione è stata impostata così***
                                If oMyTariffe.oQuoteFisse(x).bIsAGiorni = True Then
                                    '***20100203 - la quota fissa deve essere moltiplicata per il numero di utenze***
                                    impDovuto = ((oMyTariffe.oQuoteFisse(x).dImportoDep * oMyContatore.oListLetture(y).nGiorni) / nMyBaseTempo) * oMyContatore.nNumeroUtenze
                                Else
                                    impDovuto = oMyTariffe.oQuoteFisse(x).dImportoDep * oMyContatore.nNumeroUtenze
                                End If
                                'creo il nuovo oggetto dovuto scaglione
                                oQuotaFissa = New ObjTariffeQuotaFissa
                                oQuotaFissa.Id = -1
                                oQuotaFissa.nIdFattura = -1
                                oQuotaFissa.nIdLettura = oMyContatore.oListLetture(nLetturaCalcolo).IdLettura
                                oQuotaFissa.sIdEnte = oMyContatore.sIdEnte
                                oQuotaFissa.sAnno = oMyTariffe.oQuoteFisse(x).sAnno
                                oQuotaFissa.nIdQuotaFissa = oMyTariffe.oQuoteFisse(x).ID
                                oQuotaFissa.nAliquota = oMyTariffe.oQuoteFisse(x).dAliquota
                                oQuotaFissa.impQuotaFissa = impDovuto
                                oQuotaFissa.nIdTipoCanone = OggettoCanone.Canone_Depurazione
                                oQuotaFissa.tDataInserimento = Now
                                oQuotaFissa.sOperatore = sOperatore
                                'aggiorno l'array per il dettaglio iva
                                If CalcolaDettaglioIva(oQuotaFissa.nAliquota, impDovuto, oMyListAliquote) = 0 Then
                                    Return 0
                                End If
                                'aggiorno i totalizzatori
                                oMyFattura.impQuoteFisseDep += FormatNumber(impDovuto, 2)
                                If oQuotaFissa.nAliquota = 0 Then
                                    oMyFattura.impEsente += FormatNumber(oQuotaFissa.impQuotaFissa, 2)
                                Else
                                    oMyFattura.impImponibile += FormatNumber(oQuotaFissa.impQuotaFissa, 2)
                                End If
                                'aggiorno l'array
                                nList += 1
                                ReDim Preserve oListQuoteFisse(nList)
                                oListQuoteFisse(nList) = oQuotaFissa
                            End If
                            If oMyContatore.bEsenteFogQF = False Then
                                '***20100305 - la quota fissa deve essere rapportata ai giorni solo se da configurazione è stata impostata così***
                                If oMyTariffe.oQuoteFisse(x).bIsAGiorni = True Then
                                    '***20100203 - la quota fissa deve essere moltiplicata per il numero di utenze***
                                    impDovuto = ((oMyTariffe.oQuoteFisse(x).dImportoFog * oMyContatore.oListLetture(y).nGiorni) / nMyBaseTempo) * oMyContatore.nNumeroUtenze
                                Else
                                    impDovuto = oMyTariffe.oQuoteFisse(x).dImportoFog * oMyContatore.nNumeroUtenze
                                End If
                                'creo il nuovo oggetto dovuto scaglione
                                oQuotaFissa = New ObjTariffeQuotaFissa
                                oQuotaFissa.Id = -1
                                oQuotaFissa.nIdFattura = -1
                                oQuotaFissa.nIdLettura = oMyContatore.oListLetture(nLetturaCalcolo).IdLettura
                                oQuotaFissa.sIdEnte = oMyContatore.sIdEnte
                                oQuotaFissa.sAnno = oMyTariffe.oQuoteFisse(x).sAnno
                                oQuotaFissa.nIdQuotaFissa = oMyTariffe.oQuoteFisse(x).ID
                                oQuotaFissa.nAliquota = oMyTariffe.oQuoteFisse(x).dAliquota
                                oQuotaFissa.impQuotaFissa = impDovuto
                                oQuotaFissa.nIdTipoCanone = OggettoCanone.Canone_Fognatura
                                oQuotaFissa.tDataInserimento = Now
                                oQuotaFissa.sOperatore = sOperatore
                                'aggiorno l'array per il dettaglio iva
                                If CalcolaDettaglioIva(oQuotaFissa.nAliquota, impDovuto, oMyListAliquote) = 0 Then
                                    Return 0
                                End If
                                'aggiorno i totalizzatori
                                oMyFattura.impQuoteFisseFog += FormatNumber(impDovuto, 2)
                                If oQuotaFissa.nAliquota = 0 Then
                                    oMyFattura.impEsente += FormatNumber(oQuotaFissa.impQuotaFissa, 2)
                                Else
                                    oMyFattura.impImponibile += FormatNumber(oQuotaFissa.impQuotaFissa, 2)
                                End If
                                'aggiorno l'array
                                nList += 1
                                ReDim Preserve oListQuoteFisse(nList)
                                oListQuoteFisse(nList) = oQuotaFissa
                            End If
                            '*** ***
                            Exit For
                        End If
                    Next
                Next
                oMyFattura.oQuoteFisse = oListQuoteFisse
            End If
            Return 1
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::CalcoloQuoteFisse::" & Err.Message)
            Return 0
        End Try
    End Function

    Private Function CalcoloDettaglioIva(ByVal sIdEnte As String, ByVal oMyListAliquote() As oDettaglioAliquote, ByVal sOperatore As String, ByRef oMyFattura As ObjFattura) As Integer
        Dim oListDettaglioIva() As ObjDettaglioIva
        Dim oDettaglioIva As ObjDettaglioIva
        Dim nList As Integer = -1
        Dim x As Integer
        Dim impDovuto As Double = 0

        Try
            'controllo se ho già delle aliquote sulla fattura
            If Not IsNothing(oMyFattura.oDettaglioIva) Then
                oListDettaglioIva = oMyFattura.oDettaglioIva
                nList = oListDettaglioIva.GetUpperBound(0)
            End If
            If Not oMyListAliquote Is Nothing Then
                For x = 0 To oMyListAliquote.GetUpperBound(0)
                    'posizione imponibile ente
                    oDettaglioIva = New ObjDettaglioIva
                    oDettaglioIva.sIdEnte = sIdEnte
                    oDettaglioIva.sCapitolo = sCapitoloEnte
                    oDettaglioIva.nAliquota = oMyListAliquote(x).nALiquota
                    oDettaglioIva.impDettaglio = oMyListAliquote(x).impBase
                    oDettaglioIva.tDataInserimento = Now
                    oDettaglioIva.sOperatore = sOperatore
                    nList += 1
                    ReDim Preserve oListDettaglioIva(nList)
                    oListDettaglioIva(nList) = oDettaglioIva
                    'controllo se devo calcolare l'iva
                    If oMyListAliquote(x).nALiquota <> 0 Then
                        'posizione iva
                        oDettaglioIva = New ObjDettaglioIva
                        oDettaglioIva.sCapitolo = sCapitoloIva
                        oDettaglioIva.nAliquota = oMyListAliquote(x).nALiquota
                        oDettaglioIva.impDettaglio = FormatNumber((oMyListAliquote(x).impBase * oMyListAliquote(x).nALiquota) / 100, 2)
                        oDettaglioIva.tDataInserimento = Now
                        oDettaglioIva.sOperatore = sOperatore
                        nList += 1
                        ReDim Preserve oListDettaglioIva(nList)
                        oListDettaglioIva(nList) = oDettaglioIva
                        oMyFattura.impIva += FormatNumber(oDettaglioIva.impDettaglio, 2)
                    End If
                Next
            End If
            oMyFattura.impTotale = FormatNumber((oMyFattura.impImponibile + oMyFattura.impEsente + oMyFattura.impIva), 2)
            '***al momento non gestiamo l'arrotondamento***
            'oMyFattura.impArrotondamento = ArrotondaEuroIntero(oMyFattura.impTotale)
            If oMyFattura.impArrotondamento <> 0 Then
                'posizione arrotondamento
                oDettaglioIva = New ObjDettaglioIva
                oDettaglioIva.sIdEnte = sIdEnte
                oDettaglioIva.sCapitolo = sCapitoloArrotondamento
                oDettaglioIva.nAliquota = 0
                oDettaglioIva.impDettaglio = oMyFattura.impArrotondamento
                oDettaglioIva.tDataInserimento = Now
                oDettaglioIva.sOperatore = sOperatore
                nList += 1
                ReDim Preserve oListDettaglioIva(nList)
                oListDettaglioIva(nList) = oDettaglioIva
            End If
            oMyFattura.impFattura = FormatNumber((oMyFattura.impTotale + oMyFattura.impArrotondamento), 2)
            oMyFattura.oDettaglioIva = oListDettaglioIva
            Return 1
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::CalcoloDettaglioIva::" & Err.Message)
            Return 0
        End Try
    End Function
#End Region

    ''' <summary>
    ''' La funzione ridetermina gli scaglioni rapportandoli ai giorni di consumo della lettura.
    ''' </summary>
    ''' <param name="nBaseTempo">Intero contiene la base temporale di calcolo.</param>
    ''' <param name="nGGConsumo">Intero contiene i giorni di consumo su cui ricalcolare gli scaglioni.</param>
    ''' <param name="oScaglioni">Array di oggetto ObjTariffeScaglione contiene gli scaglioni di partenza.</param>
    ''' <returns>Array di oggetto ObjTariffeScaglione restituisce gli scaglioni rideterminati.</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[monicatarello]	21/10/2008	Created
    ''' </history>
    ''' <revisionHistory><revision date="19/11/2010">rapporto gli scaglioni al numero di utenze in questo modo non "sporco" il consumo con gli arrotondamenti</revision></revisionHistory>
    ''' <revisionHistory><revision date="13/02/2020">rapporto gli scaglioni oltre che ai giorni anche al numero di utenze; in questo modo non devo ricalcolare il consumo</revision></revisionHistory>
    Private Function GetScaglioniSuGGConsumo(ByVal nBaseTempo As Integer, ByVal nGGConsumo As Integer, ByVal nUtenze As Integer, ByVal oScaglioni() As OggettoScaglione) As OggettoScaglione()
        Dim oNewListScaglioni() As OggettoScaglione
        Dim oNewScaglione As OggettoScaglione
        Dim x, nNewStartScaglione As Integer

        Try
            nNewStartScaglione = oScaglioni(0).DA
            For x = 0 To oScaglioni.GetUpperBound(0)
                'memorizzo tutti i dati dello scaglione configurato
                Log.Debug("ClsElaborazione.GetScaglioniSuGGConsumo.oScaglioni(x).sDescrizioneTU->" + oScaglioni(x).sDescrizioneTU)
                oNewScaglione = New OggettoScaglione
                oNewScaglione.dAliquota = oScaglioni(x).dAliquota
                oNewScaglione.dMinimo = oScaglioni(x).dMinimo
                oNewScaglione.dTariffa = oScaglioni(x).dTariffa
                oNewScaglione.ID = oScaglioni(x).ID
                oNewScaglione.idTipoUtenza = oScaglioni(x).idTipoUtenza
                oNewScaglione.sAnno = oScaglioni(x).sAnno
                oNewScaglione.sDescrizioneTU = oScaglioni(x).sDescrizioneTU
                oNewScaglione.sIdEnte = oScaglioni(x).sIdEnte
                'calcolo la partenza dello scaglione
                oNewScaglione.DA = oScaglioni(x).DA
                Log.Debug("ClsElaborazione.GetScaglioniSuGGConsumo.oScaglioni(x).DA->" + oScaglioni(x).DA.ToString)
                If oNewScaglione.DA <> 1 Then
                    oNewScaglione.DA = nNewStartScaglione
                End If
                Log.Debug("ClsElaborazione.GetScaglioniSuGGConsumo.oNewScaglione.DA->" + oNewScaglione.DA.ToString)
                'calcolo il valore di fine scaglione in base ai giorni
                oNewScaglione.A = FormatNumber(((oScaglioni(x).A * nGGConsumo) / nBaseTempo), 2)
                Log.Debug("ClsElaborazione.GetScaglioniSuGGConsumo.oScaglioni(x).A->" + oScaglioni(x).A.ToString + ",nGGConsumo->" + nGGConsumo.ToString + ",nBaseTempo" + nBaseTempo.ToString + ",oNewScaglione.A->" + oNewScaglione.A.ToString)
                'calcolo il valore di fine scaglione in base al numero di utenze
                oNewScaglione.A = FormatNumber((oNewScaglione.A * nUtenze), 2)
                Log.Debug("ClsElaborazione.GetScaglioniSuGGConsumo.nUtenze->" + nUtenze.ToString + ",oNewScaglione.A->" + oNewScaglione.A.ToString)
                nNewStartScaglione = oNewScaglione.A + 1
                'memorizzo il nuovo scaglione
                ReDim Preserve oNewListScaglioni(x)
                oNewListScaglioni(x) = oNewScaglione
            Next

        Catch Err As Exception
            oNewListScaglioni = Nothing
            Log.Debug("Si è verificato un errore in ClsElaborazione::GetScaglioniSuGGConsumo::" & Err.Message)
        End Try
        Return oNewListScaglioni
    End Function
    'Private Function GetScaglioniSuGGConsumo(ByVal nBaseTempo As Integer, ByVal nGGConsumo As Integer, ByVal nUtenze As Integer, ByVal oScaglioni() As OggettoScaglione) As OggettoScaglione()
    '    Dim oNewListScaglioni() As OggettoScaglione
    '    Dim oNewScaglione As OggettoScaglione
    '    Dim x, nNewStartScaglione As Integer

    '    Try
    '        nNewStartScaglione = oScaglioni(0).DA
    '        For x = 0 To oScaglioni.GetUpperBound(0)
    '            'memorizzo tutti i dati dello scaglione configurato
    '            oNewScaglione = New OggettoScaglione
    '            oNewScaglione.dAliquota = oScaglioni(x).dAliquota
    '            oNewScaglione.dMinimo = oScaglioni(x).dMinimo
    '            oNewScaglione.dTariffa = oScaglioni(x).dTariffa
    '            oNewScaglione.ID = oScaglioni(x).ID
    '            oNewScaglione.idTipoUtenza = oScaglioni(x).idTipoUtenza
    '            oNewScaglione.sAnno = oScaglioni(x).sAnno
    '            oNewScaglione.sDescrizioneTU = oScaglioni(x).sDescrizioneTU
    '            oNewScaglione.sIdEnte = oScaglioni(x).sIdEnte
    '            'calcolo la partenza dello scaglione
    '            oNewScaglione.DA = oScaglioni(x).DA
    '            If oNewScaglione.DA <> 1 Then
    '                oNewScaglione.DA = nNewStartScaglione
    '            End If
    '            'calcolo il valore di fine scaglione in base ai giorni
    '            'oNewScaglione.A = FormatNumber(((oScaglioni(x).A * nGGConsumo) / nBaseTempo) * nUtenze, 2)
    '            oNewScaglione.A = FormatNumber(((oScaglioni(x).A * nGGConsumo) / nBaseTempo), 2)
    '            nNewStartScaglione = oNewScaglione.A + 1
    '            'memorizzo il nuovo scaglione
    '            ReDim Preserve oNewListScaglioni(x)
    '            oNewListScaglioni(x) = oNewScaglione
    '        Next

    '    Catch Err As Exception
    '        oNewListScaglioni = Nothing
    '        Log.Debug("Si è verificato un errore in ClsElaborazione::GetScaglioniSuGGConsumo::" & Err.Message)
    '    End Try
    '    Return oNewListScaglioni
    'End Function

    '''' -----------------------------------------------------------------------------
    '''' <summary>
    '''' La funzione determina il consumo per singola utenza applicando il tipo di arrotondamento selezionato per il periodo.
    '''' </summary>
    '''' <param name="nMyConsumo">Intero contiene il consumo totale.</param>
    '''' <param name="nMyUtenze">Intero contiene il numero di utenze.</param>
    '''' <param name="nMyArrotondamento">Intero contiene la tipologia di arrotondamento.</param>
    '''' <returns>Precisione doppia restituisce il consumo calcolato.</returns>
    '''' <remarks>
    '''' </remarks>
    '''' <history>
    '''' 	[monicatarello]	21/10/2008	Created
    '''' </history>
    '''' -----------------------------------------------------------------------------
    'Private Function GetConsumo(ByVal nMyConsumo As Integer, ByVal nMyUtenze As Integer, ByVal nMyArrotondamento As Integer) As Double
    '    Dim dMyConsumo As Double = -1

    '    Try
    '        '*** 20101119 - rapporto gli scaglioni al numero di utenze in questo modo non "sporco" il consumo con gli arrotondamenti ***
    '        dMyConsumo = (nMyConsumo / nMyUtenze)
    '        Select Case nMyArrotondamento
    '            Case 0
    '                dMyConsumo = FormatNumber(dMyConsumo, 2)
    '            Case 1
    '                dMyConsumo = CInt(dMyConsumo)
    '            Case 2
    '                dMyConsumo = CInt(dMyConsumo + 0.5)
    '        End Select
    '    Catch Err As Exception
    '        dMyConsumo = 0
    '        Log.Debug("Si è verificato un errore in ClsElaborazione::GetConsumo::" & Err.Message)
    '    End Try
    '    Return dMyConsumo
    'End Function

    Private Function CalcolaDettaglioIva(ByVal nAliquotaDett As Double, ByVal impBaseDett As Double, ByRef oAliquote() As oDettaglioAliquote) As Integer
        Try
            Dim x As Integer
            Dim IsTrovato As Integer = 0
            Dim nList As Integer = -1
            Dim oMyAliquota As oDettaglioAliquote

            If Not oAliquote Is Nothing Then
                nList = oAliquote.GetUpperBound(0)
                For x = 0 To oAliquote.GetUpperBound(0)
                    If nAliquotaDett = oAliquote(x).nALiquota Then
                        IsTrovato = 1
                        oAliquote(x).nALiquota = nAliquotaDett
                        oAliquote(x).impBase += FormatNumber(impBaseDett, 2)
                        Return 1
                    Else
                        IsTrovato = 0
                    End If
                Next
            End If
            If IsTrovato = 0 Then
                oMyAliquota = New oDettaglioAliquote
                oMyAliquota.nALiquota = nAliquotaDett
                oMyAliquota.impBase = FormatNumber(impBaseDett, 2)
                x = nList + 1
                ReDim Preserve oAliquote(x)
                oAliquote(x) = oMyAliquota
            End If

            Return 1
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::CalcolaDettaglioIva::" & Err.Message)
            Return 0
        End Try
    End Function

    ''' <summary>
    ''' Determina i MC da utilizzare per il calcolo degli scaglioni.
    ''' </summary>
    ''' <param name="nConsumoARif">Integer</param>
    ''' <param name="nConsumoDaRif">Integer</param>
    ''' <param name="nTipoUtenzaRif">Integer</param>
    ''' <param name="oScaglioneRif">Oggetto di tipo OggettoScaglione</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    Private Function GetConsumoCalcolo(ByVal nConsumoARif As Double, ByRef nConsumoDaRif As Integer, ByVal nTipoUtenzaRif As Integer, ByVal oScaglioneRif As OggettoScaglione) As Double
        Try
            Dim nConsumoCalcolo As Double = 0

            If nTipoUtenzaRif = oScaglioneRif.idTipoUtenza Then
                If nConsumoDaRif >= oScaglioneRif.DA Then
                    If nConsumoARif <= oScaglioneRif.A Then
                        nConsumoCalcolo = (nConsumoARif - nConsumoDaRif) + 1
                    Else
                        nConsumoCalcolo = (oScaglioneRif.A - nConsumoDaRif) + 1
                    End If
                End If
            End If
            Return nConsumoCalcolo
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::GetConsumoCalcolo::" & Err.Message)
            Return 0
        End Try
    End Function

    Public Function ArrotondaEuroIntero(ByVal impDaArrotondare As String) As Double
        Try
            Dim nParteDecimale As Integer
            Dim nCifreDecimali As Integer
            Dim nParteIntera As Integer

            impDaArrotondare = impDaArrotondare.Replace(".", ",")

            If InStr(impDaArrotondare, ",") = 0 Then
                nCifreDecimali = 0
            Else
                nCifreDecimali = CInt(impDaArrotondare.Substring(InStr(impDaArrotondare, ","), impDaArrotondare.Length - InStr(impDaArrotondare, ",")).Length)
            End If

            If nCifreDecimali = 1 Then
                nParteDecimale = CInt(impDaArrotondare.Substring(InStr(impDaArrotondare, ","), 1)) * 10
                nParteIntera = CInt(impDaArrotondare.Substring(0, InStr(impDaArrotondare, ",") - 1))
            ElseIf nCifreDecimali = 0 Then
                nParteDecimale = 0
                nParteIntera = impDaArrotondare
            Else
                nParteDecimale = CInt(impDaArrotondare.Substring(InStr(impDaArrotondare, ","), 2))
                nParteIntera = CInt(impDaArrotondare.Substring(0, InStr(impDaArrotondare, ",") - 1))
            End If

            If nParteDecimale > 49 Then
                If impDaArrotondare > 0 Then
                    ArrotondaEuroIntero = (100 - nParteDecimale) / 100
                Else
                    ArrotondaEuroIntero = (100 + nParteDecimale) / 100
                End If
            ElseIf nParteDecimale = 0 Then
                ArrotondaEuroIntero = 0
            Else
                If impDaArrotondare > 0 Then
                    ArrotondaEuroIntero = (-nParteDecimale) / 100
                Else
                    ArrotondaEuroIntero = (nParteDecimale) / 100
                End If
            End If
        Catch Err As Exception
            Log.Debug("Si è verificato un errore in ClsElaborazione::ArrotondaEuroIntero::" & Err.Message)
            Return 0
        End Try
    End Function
End Class
