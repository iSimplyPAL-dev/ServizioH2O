Imports AnagInterface

Namespace MotoreH2o.Oggetti
    <Serializable()>
    Public Class objContatore
        Private _nIdContatore As Integer
        Private _sIdEnte As String
        Private _sIdEnteAppartenenza As String
        Private _nIdIntestatario As Integer
        Private _nIdUtente As Integer
        Private _nIdImpianto As Integer
        Private _sMatricola As String
        Private _nIdVia As Integer
        Private _sUbicazione As String
        Private _sCivico As String
        Private _sEsponenteCivico As String
        Private _sFrazione As String
        Private _nNumeroUtenze As Integer
        Private _nTipoUtenza As Integer
        Private _nTipoContatore As Integer
        Private _sCifreContatore As String
        Private _nFondoScala As Integer
        Private _nCodDepurazione As Integer
        Private _nCodFognatura As Integer
        Private _bEsenteDepurazione As Boolean
        Private _bEsenteFognatura As Boolean
        Private _bEsenteAcqua As Boolean
        '*** 20121217 - calcolo quota fissa acqua+depurazione+fognatura ***
        Private _bEsenteAcquaQF As Boolean
        Private _bEsenteFogQF As Boolean
        Private _bEsenteDepQF As Boolean
        Private _sDataAttivazione As String
        Private _sDataSostituzione As String
        Private _sDataRimTemp As String
        Private _sDataCessazione As String
        Private _nIdContratto As Integer
        Private _sStatoContatore As String
        Private _nGiro As Integer
        Private _sSequenza As String
        Private _nPosizione As Integer
        Private _sProgressivo As String
        Private _sLatoStrada As String
        Private _nDiametroContatore As Integer
        Private _nDiametroPresa As Integer
        Private _sNumeroUtente As String
        Private _nIdContatorePrec As Integer
        Private _sMatricolaContatorePrec As String
        Private _nIdContatoreSucc As Integer
        Private _sMatricolaContatoreSucc As String
        Private _bIgnoraMora As Boolean
        Private _sNote As String
        Private _oDatiCatastali() As objDatiCatastali
        Private _oAnagIntestatario As DettaglioAnagrafica
        Private _oAnagUtente As DettaglioAnagrafica
        Private _oListLetture() As ObjLettura
        Private _nConsumoMinimo As Integer
        Private _sDataSospensioneUtenza As String
        Private _bUtenteSospeso As Boolean
        Private _sQuoteAgevolate As String
        Private _sCodiceFabbricante As String
        Private _nCodIva As Integer
        Private _sPenalita As String
        Private _sCodiceISTAT As String
        Private _nIdMinimo As Integer
        Private _nIdAttivita As Integer
        Private _nSpesa As Double
        Private _nDiritti As Double
        Private _bIsPendente As Boolean
        Private _sProvenienza As String
        Private _tDataInserimento As Date
        Private _tDataVariazione As Date
        Private _listSubContatori() As ObjSubContatore
#Region "Dati Agenzia Entrate"
        Private _nProprietario As Integer
        Private _sSezioneCatast As String
        Private _sParticellaCatast As String
        Private _sEstensioneParticellaCatast As String
        Private _nIdTitoloOccupazione As Integer
        Private _sTipoUnita As String
        Private _nIdAssenzaDatiCatastali As Integer
        Private _nIdTipoUtenza As Integer
#End Region

        Public Property nIdContatore() As Integer
            Get
                Return _nIdContatore
            End Get
            Set(ByVal Value As Integer)
                _nIdContatore = Value
            End Set
        End Property
        Public Property sIdEnte() As String
            Get
                Return _sIdEnte
            End Get
            Set(ByVal Value As String)
                _sIdEnte = Value
            End Set
        End Property
        Public Property sIdEnteAppartenenza() As String
            Get
                Return _sIdEnteAppartenenza
            End Get
            Set(ByVal Value As String)
                _sIdEnteAppartenenza = Value
            End Set
        End Property
        Public Property nIdIntestatario() As Integer
            Get
                Return _nIdIntestatario
            End Get
            Set(ByVal Value As Integer)
                _nIdIntestatario = Value
            End Set
        End Property
        Public Property nIdUtente() As Integer
            Get
                Return _nIdUtente
            End Get
            Set(ByVal Value As Integer)
                _nIdUtente = Value
            End Set
        End Property
        Public Property nIdImpianto() As Integer
            Get
                Return _nIdImpianto
            End Get
            Set(ByVal Value As Integer)
                _nIdImpianto = Value
            End Set
        End Property
        Public Property sMatricola() As String
            Get
                Return _sMatricola
            End Get
            Set(ByVal Value As String)
                _sMatricola = Value
            End Set
        End Property
        Public Property nIdVia() As Integer
            Get
                Return _nIdVia
            End Get
            Set(ByVal Value As Integer)
                _nIdVia = Value
            End Set
        End Property
        Public Property sUbicazione() As String
            Get
                Return _sUbicazione
            End Get
            Set(ByVal Value As String)
                _sUbicazione = Value
            End Set
        End Property
        Public Property sCivico() As String
            Get
                Return _sCivico
            End Get
            Set(ByVal Value As String)
                _sCivico = Value
            End Set
        End Property
        Public Property sEsponenteCivico() As String
            Get
                Return _sEsponenteCivico
            End Get
            Set(ByVal Value As String)
                _sEsponenteCivico = Value
            End Set
        End Property
        Public Property sFrazione() As String
            Get
                Return _sFrazione
            End Get
            Set(ByVal Value As String)
                _sFrazione = Value
            End Set
        End Property
        Public Property nNumeroUtenze() As Integer
            Get
                Return _nNumeroUtenze
            End Get
            Set(ByVal Value As Integer)
                _nNumeroUtenze = Value
            End Set
        End Property
        Public Property nTipoUtenza() As Integer
            Get
                Return _nTipoUtenza
            End Get
            Set(ByVal Value As Integer)
                _nTipoUtenza = Value
            End Set
        End Property
        Public Property nTipoContatore() As Integer
            Get
                Return _nTipoContatore
            End Get
            Set(ByVal Value As Integer)
                _nTipoContatore = Value
            End Set
        End Property
        Public Property sCifreContatore() As String
            Get
                Return _sCifreContatore
            End Get
            Set(ByVal Value As String)
                _sCifreContatore = Value
            End Set
        End Property
        Public Property nFondoScala() As Integer
            Get
                Return _nFondoScala
            End Get
            Set(ByVal Value As Integer)
                _nFondoScala = Value
            End Set
        End Property
        Public Property nCodDepurazione() As Integer
            Get
                Return _nCodDepurazione
            End Get
            Set(ByVal Value As Integer)
                _nCodDepurazione = Value
            End Set
        End Property
        Public Property nCodFognatura() As Integer
            Get
                Return _nCodFognatura
            End Get
            Set(ByVal Value As Integer)
                _nCodFognatura = Value
            End Set
        End Property
        Public Property bEsenteDepurazione() As Boolean
            Get
                Return _bEsenteDepurazione
            End Get
            Set(ByVal Value As Boolean)
                _bEsenteDepurazione = Value
            End Set
        End Property
        Public Property bEsenteFognatura() As Boolean
            Get
                Return _bEsenteFognatura
            End Get
            Set(ByVal Value As Boolean)
                _bEsenteFognatura = Value
            End Set
        End Property
        Public Property bEsenteAcqua() As Boolean
            Get
                Return _bEsenteAcqua
            End Get
            Set(ByVal Value As Boolean)
                _bEsenteAcqua = Value
            End Set
        End Property
        '*** 20121217 - calcolo quota fissa acqua+depurazione+fognatura ***
        Public Property bEsenteAcquaQF() As Boolean
            Get
                Return _bEsenteAcquaQF
            End Get
            Set(ByVal Value As Boolean)
                _bEsenteAcquaQF = Value
            End Set
        End Property
        Public Property bEsenteDepQF() As Boolean
            Get
                Return _bEsenteDepQF
            End Get
            Set(ByVal Value As Boolean)
                _bEsenteDepQF = Value
            End Set
        End Property

        Public Property bEsenteFogQF() As Boolean
            Get
                Return _bEsenteFogQF
            End Get
            Set(ByVal Value As Boolean)
                _bEsenteFogQF = Value
            End Set
        End Property

        Public Property sDataAttivazione() As String
            Get
                Return _sDataAttivazione
            End Get
            Set(ByVal Value As String)
                _sDataAttivazione = Value
            End Set
        End Property
        Public Property sDataSostituzione() As String
            Get
                Return _sDataSostituzione
            End Get
            Set(ByVal Value As String)
                _sDataSostituzione = Value
            End Set
        End Property
        Public Property sDataRimTemp() As String
            Get
                Return _sDataRimTemp
            End Get
            Set(ByVal Value As String)
                _sDataRimTemp = Value
            End Set
        End Property
        Public Property sDataCessazione() As String
            Get
                Return _sDataCessazione
            End Get
            Set(ByVal Value As String)
                _sDataCessazione = Value
            End Set
        End Property
        Public Property nIdContratto() As Integer
            Get
                Return _nIdContratto
            End Get
            Set(ByVal Value As Integer)
                _nIdContratto = Value
            End Set
        End Property
        Public Property sStatoContatore() As String
            Get
                Return _sStatoContatore
            End Get
            Set(ByVal Value As String)
                _sStatoContatore = Value
            End Set
        End Property
#Region "Dati Agenzia Entrate"
        Public Property nProprietario() As Integer
            Get
                Return _nProprietario
            End Get
            Set(ByVal Value As Integer)
                _nProprietario = Value
            End Set
        End Property
        Public Property sSezioneCatast() As String
            Get
                Return _sSezioneCatast
            End Get
            Set(ByVal Value As String)
                _sSezioneCatast = Value
            End Set
        End Property
        Public Property sParticellaCatast() As String
            Get
                Return _sParticellaCatast
            End Get
            Set(ByVal Value As String)
                _sParticellaCatast = Value
            End Set
        End Property
        Public Property sEstensioneParticellaCatast() As String
            Get
                Return _sEstensioneParticellaCatast
            End Get
            Set(ByVal Value As String)
                _sEstensioneParticellaCatast = Value
            End Set
        End Property
        Public Property nIdTitoloOccupazione() As Integer
            Get
                Return _nIdTitoloOccupazione
            End Get
            Set(ByVal Value As Integer)
                _nIdTitoloOccupazione = Value
            End Set
        End Property
        Public Property sTipoUnita() As String
            Get
                Return _sTipoUnita
            End Get
            Set(ByVal Value As String)
                _sTipoUnita = Value
            End Set
        End Property
        Public Property nIdAssenzaDatiCatastali() As Integer
            Get
                Return _nIdAssenzaDatiCatastali
            End Get
            Set(ByVal Value As Integer)
                _nIdAssenzaDatiCatastali = Value
            End Set
        End Property
        Public Property nIdTipoUtenza() As Integer
            Get
                Return _nIdTipoUtenza
            End Get
            Set(ByVal Value As Integer)
                _nIdTipoUtenza = Value
            End Set
        End Property
#End Region
        Public Property nGiro() As Integer
            Get
                Return _nGiro
            End Get
            Set(ByVal Value As Integer)
                _nGiro = Value
            End Set
        End Property
        Public Property sSequenza() As String
            Get
                Return _sSequenza
            End Get
            Set(ByVal Value As String)
                _sSequenza = Value
            End Set
        End Property
        Public Property nPosizione() As Integer
            Get
                Return _nPosizione
            End Get
            Set(ByVal Value As Integer)
                _nPosizione = Value
            End Set
        End Property
        Public Property sProgressivo() As String
            Get
                Return _sProgressivo
            End Get
            Set(ByVal Value As String)
                _sProgressivo = Value
            End Set
        End Property
        Public Property sLatoStrada() As String
            Get
                Return _sLatoStrada
            End Get
            Set(ByVal Value As String)
                _sLatoStrada = Value
            End Set
        End Property
        Public Property nDiametroContatore() As Integer
            Get
                Return _nDiametroContatore
            End Get
            Set(ByVal Value As Integer)
                _nDiametroContatore = Value
            End Set
        End Property
        Public Property nDiametroPresa() As Integer
            Get
                Return _nDiametroPresa
            End Get
            Set(ByVal Value As Integer)
                _nDiametroPresa = Value
            End Set
        End Property
        Public Property sNumeroUtente() As String
            Get
                Return _sNumeroUtente
            End Get
            Set(ByVal Value As String)
                _sNumeroUtente = Value
            End Set
        End Property
        Public Property nIdContatorePrec() As Integer
            Get
                Return _nIdContatorePrec
            End Get
            Set(ByVal Value As Integer)
                _nIdContatorePrec = Value
            End Set
        End Property
        Public Property sMatricolaContatorePrec() As String
            Get
                Return _sMatricolaContatorePrec
            End Get
            Set(ByVal Value As String)
                _sMatricolaContatorePrec = Value
            End Set
        End Property
        Public Property nIdContatoreSucc() As Integer
            Get
                Return _nIdContatoreSucc
            End Get
            Set(ByVal Value As Integer)
                _nIdContatoreSucc = Value
            End Set
        End Property
        Public Property sMatricolaContatoreSucc() As String
            Get
                Return _sMatricolaContatoreSucc
            End Get
            Set(ByVal Value As String)
                _sMatricolaContatoreSucc = Value
            End Set
        End Property
        Public Property bIgnoraMora() As Boolean
            Get
                Return _bIgnoraMora
            End Get
            Set(ByVal Value As Boolean)
                _bIgnoraMora = Value
            End Set
        End Property
        Public Property oDatiCatastali() As objDatiCatastali()
            Get
                Return _oDatiCatastali
            End Get
            Set(ByVal Value As objDatiCatastali())
                _oDatiCatastali = Value
            End Set
        End Property
        Public Property oAnagIntestatario() As DettaglioAnagrafica
            Get
                Return _oAnagIntestatario
            End Get
            Set(ByVal Value As DettaglioAnagrafica)
                _oAnagIntestatario = Value
            End Set
        End Property
        Public Property oAnagUtente() As DettaglioAnagrafica
            Get
                Return _oAnagUtente
            End Get
            Set(ByVal Value As DettaglioAnagrafica)
                _oAnagUtente = Value
            End Set
        End Property
        Public Property oListLetture() As ObjLettura()
            Get
                Return _oListLetture
            End Get
            Set(ByVal Value As ObjLettura())
                _oListLetture = Value
            End Set
        End Property
        Public Property sNote() As String
            Get
                Return _sNote
            End Get
            Set(ByVal Value As String)
                _sNote = Value
            End Set
        End Property

        Public Property nConsumoMinimo() As Integer
            Get
                Return _nConsumoMinimo
            End Get
            Set(ByVal Value As Integer)
                _nConsumoMinimo = Value
            End Set
        End Property
        Public Property sDataSospensioneUtenza() As String
            Get
                Return _sDataSospensioneUtenza
            End Get
            Set(ByVal Value As String)
                _sDataSospensioneUtenza = Value
            End Set
        End Property
        Public Property bUtenteSospeso() As Boolean
            Get
                Return _bUtenteSospeso
            End Get
            Set(ByVal Value As Boolean)
                _bUtenteSospeso = Value
            End Set
        End Property
        Public Property sQuoteAgevolate() As String
            Get
                Return _sQuoteAgevolate
            End Get
            Set(ByVal Value As String)
                _sQuoteAgevolate = Value
            End Set
        End Property
        Public Property sCodiceFabbricante() As String
            Get
                Return _sCodiceFabbricante
            End Get
            Set(ByVal Value As String)
                _sCodiceFabbricante = Value
            End Set
        End Property
        Public Property nCodIva() As Integer
            Get
                Return _nCodIva
            End Get
            Set(ByVal Value As Integer)
                _nCodIva = Value
            End Set
        End Property
        Public Property sPenalita() As String
            Get
                Return _sPenalita
            End Get
            Set(ByVal Value As String)
                _sPenalita = Value
            End Set
        End Property
        Public Property sCodiceISTAT() As String
            Get
                Return _sCodiceISTAT
            End Get
            Set(ByVal Value As String)
                _sCodiceISTAT = Value
            End Set
        End Property
        Public Property nIdMinimo() As Integer
            Get
                Return _nIdMinimo
            End Get
            Set(ByVal Value As Integer)
                _nIdMinimo = Value
            End Set
        End Property
        Public Property nIdAttivita() As Integer
            Get
                Return _nIdAttivita
            End Get
            Set(ByVal Value As Integer)
                _nIdAttivita = Value
            End Set
        End Property
        Public Property nSpesa() As Double
            Get
                Return _nSpesa
            End Get
            Set(ByVal Value As Double)
                _nSpesa = Value
            End Set
        End Property
        Public Property nDiritti() As Double
            Get
                Return _nDiritti
            End Get
            Set(ByVal Value As Double)
                _nDiritti = Value
            End Set
        End Property
        Public Property bIsPendente() As Boolean
            Get
                Return _bIsPendente
            End Get
            Set(ByVal Value As Boolean)
                _bIsPendente = Value
            End Set
        End Property
        Public Property sProvenienza() As String
            Get
                Return _sProvenienza
            End Get
            Set(ByVal Value As String)
                _sProvenienza = Value
            End Set
        End Property
        Public Property tDataInserimento() As Date
            Get
                Return _tDataInserimento
            End Get
            Set(ByVal Value As Date)
                _tDataInserimento = Value
            End Set
        End Property
        Public Property tDataVariazione() As Date
            Get
                Return _tDataVariazione
            End Get
            Set(ByVal Value As Date)
                _tDataVariazione = Value
            End Set
        End Property
        Public Property oListSubContatori() As ObjSubContatore()
            Get
                Return _listSubContatori
            End Get
            Set(ByVal Value As ObjSubContatore())
                _listSubContatori = Value
            End Set
        End Property

        Public Sub New()
            nIdContatore = -1
            sIdEnte = ""
            sIdEnteAppartenenza = ""
            nIdIntestatario = -1
            nIdUtente = -1
            nIdImpianto = 0
            sMatricola = ""
            nIdVia = -1
            sUbicazione = ""
            sCivico = ""
            sFrazione = ""
            sEsponenteCivico = ""
            nNumeroUtenze = 0
            nTipoUtenza = 0
            nTipoContatore = 0
            sCifreContatore = ""
            nFondoScala = 99999
            nCodDepurazione = 0
            nCodFognatura = 0
            bEsenteDepurazione = False
            bEsenteFognatura = False
            bEsenteAcqua = False
            sDataAttivazione = DateTime.MaxValue.ToString
            sDataSostituzione = DateTime.MaxValue.ToString
            sDataRimTemp = DateTime.MaxValue.ToString
            sDataCessazione = DateTime.MaxValue.ToString
            nIdContratto = -1
            sStatoContatore = ""
            '#Region "Dati Agenzia Entrate"
            nProprietario = -1
            sSezioneCatast = ""
            sParticellaCatast = ""
            sEstensioneParticellaCatast = ""
            nIdTitoloOccupazione = -1
            sTipoUnita = ""
            nIdAssenzaDatiCatastali = -1
            nIdTipoUtenza = -1
            '#End Region
            nGiro = 0
            sSequenza = ""
            nPosizione = 0
            sProgressivo = ""
            sLatoStrada = ""
            nDiametroContatore = 0
            nDiametroPresa = 0
            sNumeroUtente = ""
            nIdContatorePrec = 0
            sMatricolaContatorePrec = ""
            nIdContatoreSucc = 0
            sMatricolaContatoreSucc = ""
            bIgnoraMora = False
            oDatiCatastali = Nothing
            oAnagIntestatario = Nothing
            oAnagUtente = Nothing
            oListLetture = Nothing
            sNote = ""

            nConsumoMinimo = 0
            sDataSospensioneUtenza = DateTime.MaxValue.ToString
            bUtenteSospeso = False
            sQuoteAgevolate = ""
            sCodiceFabbricante = ""
            nCodIva = 0
            sPenalita = ""
            sCodiceISTAT = ""
            nIdMinimo = 0
            nIdAttivita = 0
            nSpesa = 0
            nDiritti = 0
            bIsPendente = False
            sProvenienza = ""
            tDataInserimento = Date.MaxValue
            tDataVariazione = Date.MaxValue
            oListSubContatori = Nothing
        End Sub
    End Class

    <Serializable()>
    Public Class objDatiCatastali
        Private _nIdCatastale As Integer
        Private _nIdContatore As Integer
        Private _sInterno As String
        Private _sPiano As String
        Private _sFoglio As String
        Private _sNumero As String
        Private _nSubalterno As Integer
        Private _sSezione As String
        Private _sEstensioneParticella As String
        Private _sIdTipoParticella As String

        Public Property nIdCatastale() As Integer
            Get
                Return _nIdCatastale
            End Get
            Set(ByVal Value As Integer)
                _nIdCatastale = Value
            End Set
        End Property
        Public Property nIdContatore() As Integer
            Get
                Return _nIdContatore
            End Get
            Set(ByVal Value As Integer)
                _nIdContatore = Value
            End Set
        End Property
        Public Property sInterno() As String
            Get
                Return _sInterno
            End Get
            Set(ByVal Value As String)
                _sInterno = Value
            End Set
        End Property
        Public Property sPiano() As String
            Get
                Return _sPiano
            End Get
            Set(ByVal Value As String)
                _sPiano = Value
            End Set
        End Property
        Public Property sFoglio() As String
            Get
                Return _sFoglio
            End Get
            Set(ByVal Value As String)
                _sFoglio = Value
            End Set
        End Property
        Public Property sNumero() As String
            Get
                Return _sNumero
            End Get
            Set(ByVal Value As String)
                _sNumero = Value
            End Set
        End Property
        Public Property nSubalterno() As Integer
            Get
                Return _nSubalterno
            End Get
            Set(ByVal Value As Integer)
                _nSubalterno = Value
            End Set
        End Property
        Public Property sSezione() As String
            Get
                Return _sSezione
            End Get
            Set(ByVal Value As String)
                _sSezione = Value
            End Set
        End Property
        Public Property sEstensioneParticella() As String
            Get
                Return _sEstensioneParticella
            End Get
            Set(ByVal Value As String)
                _sEstensioneParticella = Value
            End Set
        End Property
        Public Property sIdTipoParticella() As String
            Get
                Return _sIdTipoParticella
            End Get
            Set(ByVal Value As String)
                _sIdTipoParticella = Value
            End Set
        End Property

        Public Sub New()
            nIdCatastale = -1
            nIdContatore = -1
            sInterno = ""
            sPiano = ""
            sFoglio = ""
            sNumero = ""
            nSubalterno = -1
            sSezione = ""
            sEstensioneParticella = ""
            sIdTipoParticella = ""
        End Sub
    End Class


    <Serializable()>
    Public Class ObjSubContatore
        Private _idsubcontatore As Integer
        Private _idcontatoreprincipale As Integer
        Private _matricola As String
        Private _cognomeintestatario As String
        Private _nomeintestatario As String
        Private _ubicazione As String
        Private _periodo As String
        Private _tDataInserimento As DateTime

        Public Property IdSubContatore() As Integer
            Get
                Return _idsubcontatore
            End Get
            Set(ByVal Value As Integer)
                _idsubcontatore = Value
            End Set
        End Property
        Public Property IdContatorePrincipale() As Integer
            Get
                Return _idcontatoreprincipale
            End Get
            Set(ByVal Value As Integer)
                _idcontatoreprincipale = Value
            End Set
        End Property
        Public Property sMatricola() As String
            Get
                Return _matricola
            End Get
            Set(ByVal Value As String)
                _matricola = Value
            End Set
        End Property
        Public Property sCognomeIntestatario() As String
            Get
                Return _cognomeintestatario
            End Get
            Set(ByVal Value As String)
                _cognomeintestatario = Value
            End Set
        End Property
        Public Property sNomeIntestatario() As String
            Get
                Return _nomeintestatario
            End Get
            Set(ByVal Value As String)
                _nomeintestatario = Value
            End Set
        End Property
        Public Property sPeriodo() As String
            Get
                Return _periodo
            End Get
            Set(ByVal Value As String)
                _periodo = Value
            End Set
        End Property
        Public Property sUbicazione() As String
            Get
                Return _ubicazione
            End Get
            Set(ByVal Value As String)
                _ubicazione = Value
            End Set
        End Property
        Public Property tDataInserimento() As Date
            Get
                Return _tDataInserimento
            End Get
            Set(ByVal Value As Date)
                _tDataInserimento = Value
            End Set
        End Property

        Public Sub New()
            IdSubContatore = -1
            IdContatorePrincipale = -1
            sMatricola = ""
            sCognomeIntestatario = ""
            sNomeIntestatario = ""
            sUbicazione = ""
            tDataInserimento = Now
        End Sub
    End Class
End Namespace
