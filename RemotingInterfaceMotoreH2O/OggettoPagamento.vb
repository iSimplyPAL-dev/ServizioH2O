Namespace MotoreH2o.Oggetti
    <Serializable()> _
    Public Class OggettoPagamento
        Private _Id As Integer = -1
        Private _nIdImport As Integer = -1
        Private _nIdFlusso As Integer = -1
        Private _IdFatturaNota As Integer = -1
        Private _nCodUtente As Integer = -1
        Private _nPeriodo As Integer = -1
        Private _sIdEnte As String = ""
        Private _sDataFattura As String = DateTime.MaxValue.ToString
        Private _sNumeroFattura As String = ""
        Private _nImportoEmesso As Double = 0
        Private _sNRata As String = ""
        Private _nImportoRata As Double = 0
        Private _sDataPagamento As String = DateTime.MaxValue.ToString
        Private _nImportoPagamento As Double = 0
        Private _sTipoPagamento As String = ""
        Private _sNote As String = ""
        Private _sOperatore As String = ""
        Private _sCognome As String = ""
        Private _sNome As String = ""
        Private _sCodFiscalePIva As String = ""
        Private _sVia As String = ""
        Private _sCivico As String = ""
        Private _sInterno As String = ""
        Private _sAnnoEmissione As String = ""
        Private _sDataAccredito As String = DateTime.MaxValue.ToString
        Private _sDataAccreditoAl As String = DateTime.MaxValue.ToString
        Private _sSegno As String
        Private _sProvenienza As String = ""
        Private _sTipoBollettino As String = ""
        Private _sCodBollettino As String = ""
        Private _sProgCaricamento As String = ""
        Private _sProgSelezione As String = ""
        Private _sCCBeneficiario As String = ""
        Private _sUfficioSportello As String = ""
        Private _sDivisa As String = "E"
        Private _tDataInsert As Date = Now
        Private _bFlagDettaglio As Boolean = False

        Public Property ID() As Integer
            Get
                Return _Id
            End Get
            Set(ByVal Value As Integer)
                _Id = Value
            End Set
        End Property
        Public Property IDImportazione() As Integer
            Get
                Return _nIdImport
            End Get
            Set(ByVal Value As Integer)
                _nIdImport = Value
            End Set
        End Property
        Public Property IDFlusso() As Integer
            Get
                Return _nIdFlusso
            End Get
            Set(ByVal Value As Integer)
                _nIdFlusso = Value
            End Set
        End Property
        Public Property IdFatturaNota() As Integer
            Get
                Return _IdFatturaNota
            End Get
            Set(ByVal Value As Integer)
                _IdFatturaNota = Value
            End Set
        End Property
        Public Property nCodUtente() As Integer
            Get
                Return _nCodUtente
            End Get
            Set(ByVal Value As Integer)
                _nCodUtente = Value
            End Set
        End Property
        Public Property nPeriodo() As Integer
            Get
                Return _nPeriodo
            End Get
            Set(ByVal Value As Integer)
                _nPeriodo = Value
            End Set
        End Property
        Public Property IDEnte() As String
            Get
                Return _sIdEnte
            End Get
            Set(ByVal Value As String)
                _sIdEnte = Value
            End Set
        End Property
        Public Property sAnnoEmissioneFattura() As String
            Get
                Return _sAnnoEmissione
            End Get
            Set(ByVal Value As String)
                _sAnnoEmissione = Value
            End Set
        End Property
        Public Property sDataFattura() As String
            Get
                Return _sDataFattura
            End Get
            Set(ByVal Value As String)
                _sDataFattura = Value
            End Set
        End Property
        Public Property sNumeroFattura() As String
            Get
                Return _sNumeroFattura
            End Get
            Set(ByVal Value As String)
                _sNumeroFattura = Value
            End Set
        End Property
        Public Property sNRata() As String
            Get
                Return _sNRata
            End Get
            Set(ByVal Value As String)
                _sNRata = Value
            End Set
        End Property
        Public Property ImportoRata() As Double
            Get
                Return _nImportoRata
            End Get
            Set(ByVal Value As Double)
                _nImportoRata = Value
            End Set
        End Property
        Public Property sDataPagamento() As String
            Get
                Return _sDataPagamento
            End Get
            Set(ByVal Value As String)
                _sDataPagamento = Value
            End Set
        End Property
        Public Property ImportoPagamento() As Double
            Get
                Return _nImportoPagamento
            End Get
            Set(ByVal Value As Double)
                _nImportoPagamento = Value
            End Set
        End Property
        Public Property ImportoEmesso() As Double
            Get
                Return _nImportoEmesso
            End Get
            Set(ByVal Value As Double)
                _nImportoEmesso = Value
            End Set
        End Property
        Public Property sTipoPagamento() As String
            Get
                Return _sTipoPagamento
            End Get
            Set(ByVal Value As String)
                _sTipoPagamento = Value
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
        Public Property sOperatore() As String
            Get
                Return _sOperatore
            End Get
            Set(ByVal Value As String)
                _sOperatore = Value
            End Set
        End Property
        Public Property sCognome() As String
            Get
                Return _sCognome
            End Get
            Set(ByVal Value As String)
                _sCognome = Value
            End Set
        End Property
        Public Property sNome() As String
            Get
                Return _sNome
            End Get
            Set(ByVal Value As String)
                _sNome = Value
            End Set
        End Property
        Public Property sCodFiscalePIva() As String
            Get
                Return _sCodFiscalePIva
            End Get
            Set(ByVal Value As String)
                _sCodFiscalePIva = Value
            End Set
        End Property
        Public Property sVia() As String
            Get
                Return _sVia
            End Get
            Set(ByVal Value As String)
                _sVia = Value
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
        Public Property sInterno() As String
            Get
                Return _sInterno
            End Get
            Set(ByVal Value As String)
                _sInterno = Value
            End Set
        End Property
        Public Property sDataAccredito() As String
            Get
                Return _sDataAccredito
            End Get
            Set(ByVal Value As String)
                _sDataAccredito = Value
            End Set
        End Property
        Public Property sDataAccreditoAl() As String
            Get
                Return _sDataAccreditoAl
            End Get
            Set(ByVal Value As String)
                _sDataAccreditoAl = Value
            End Set
        End Property
        Public Property sSegno() As String
            Get
                Return _sSegno
            End Get
            Set(ByVal Value As String)
                _sSegno = Value
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
        Public Property sTipoBollettino() As String
            Get
                Return _sTipoBollettino
            End Get
            Set(ByVal Value As String)
                _sTipoBollettino = Value
            End Set
        End Property
        Public Property sCodBollettino() As String
            Get
                Return _sCodBollettino
            End Get
            Set(ByVal Value As String)
                _sCodBollettino = Value
            End Set
        End Property
        Public Property sProgCaricamento() As String
            Get
                Return _sProgCaricamento
            End Get
            Set(ByVal Value As String)
                _sProgCaricamento = Value
            End Set
        End Property
        Public Property sProgSelezione() As String
            Get
                Return _sProgSelezione
            End Get
            Set(ByVal Value As String)
                _sProgSelezione = Value
            End Set
        End Property
        Public Property sCCBeneficiario() As String
            Get
                Return _sCCBeneficiario
            End Get
            Set(ByVal Value As String)
                _sCCBeneficiario = Value
            End Set
        End Property
        Public Property sUfficioSportello() As String
            Get
                Return _sUfficioSportello
            End Get
            Set(ByVal Value As String)
                _sUfficioSportello = Value
            End Set
        End Property
        Public Property sDivisa() As String
            Get
                Return _sDivisa
            End Get
            Set(ByVal Value As String)
                _sDivisa = Value
            End Set
        End Property
        Public Property tDataInsert() As Date
            Get
                Return _tDataInsert
            End Get
            Set(ByVal Value As Date)
                _tDataInsert = Value
            End Set
        End Property
        Public Property bFlagDettaglio() As Boolean
            Get
                Return _bFlagDettaglio
            End Get
            Set(ByVal Value As Boolean)
                _bFlagDettaglio = Value
            End Set
        End Property
    End Class


    <Serializable()>
    Public Class ObjImportPagamenti
        Private _nID As Integer = -1
        Private _nStatoAcq As Integer = -1
        Private _nRcDaAcquisire As Integer = 0
        Private _nRcAcquisiti As Integer = 0
        Private _nRcScarti As Integer = 0
        Private _sIdEnte As String = ""
        Private _sFileAcq As String = ""
        Private _sEsito As String = ""
        Private _sFileScarti As String = ""
        Private _impDaAcquisire As Double = 0
        Private _impAcquisiti As Double = 0
        Private _impScarti As Double = 0
        Private _tDataAcq As Date = DateTime.MaxValue
        Private _sOperatore As String = ""

        Public Property Id() As Integer
            Get
                Return _nID
            End Get
            Set(ByVal Value As Integer)
                _nID = Value
            End Set
        End Property
        Public Property nStatoAcq() As Integer
            Get
                Return _nStatoAcq
            End Get
            Set(ByVal Value As Integer)
                _nStatoAcq = Value
            End Set
        End Property
        Public Property nRcDaAcquisire() As Integer
            Get
                Return _nRcDaAcquisire
            End Get
            Set(ByVal Value As Integer)
                _nRcDaAcquisire = Value
            End Set
        End Property
        Public Property nRcAcquisiti() As Integer
            Get
                Return _nRcAcquisiti
            End Get
            Set(ByVal Value As Integer)
                _nRcAcquisiti = Value
            End Set
        End Property
        Public Property nRcScarti() As Integer
            Get
                Return _nRcScarti
            End Get
            Set(ByVal Value As Integer)
                _nRcScarti = Value
            End Set
        End Property
        Public Property IdEnte() As String
            Get
                Return _sIdEnte
            End Get
            Set(ByVal Value As String)
                _sIdEnte = Value
            End Set
        End Property
        Public Property sFileAcq() As String
            Get
                Return _sFileAcq
            End Get
            Set(ByVal Value As String)
                _sFileAcq = Value
            End Set
        End Property
        Public Property sEsito() As String
            Get
                Return _sEsito
            End Get
            Set(ByVal Value As String)
                _sEsito = Value
            End Set
        End Property
        Public Property sFileScarti() As String
            Get
                Return _sFileScarti
            End Get
            Set(ByVal Value As String)
                _sFileScarti = Value
            End Set
        End Property
        Public Property impDaAcquisire() As Double
            Get
                Return _impDaAcquisire
            End Get
            Set(ByVal Value As Double)
                _impDaAcquisire = Value
            End Set
        End Property
        Public Property impAcquisiti() As Double
            Get
                Return _impAcquisiti
            End Get
            Set(ByVal Value As Double)
                _impAcquisiti = Value
            End Set
        End Property
        Public Property impScarti() As Double
            Get
                Return _impScarti
            End Get
            Set(ByVal Value As Double)
                _impScarti = Value
            End Set
        End Property
        Public Property tDataAcq() As Date
            Get
                Return _tDataAcq
            End Get
            Set(ByVal Value As Date)
                _tDataAcq = Value
            End Set
        End Property
        Public Property sOperatore() As String
            Get
                Return _sOperatore
            End Get
            Set(ByVal Value As String)
                _sOperatore = Value
            End Set
        End Property
    End Class

    <Serializable()>
    Public Class ObjCondizioniScarto
        Private _nID As Integer = -1
        Private _sContoCorrente As String = ""
        Private _sTipoBollettino As String = ""
        Private _sTipoScarto As String = ""

        Public Property ID() As Integer
            Get
                Return _nID
            End Get
            Set(ByVal Value As Integer)
                _nID = Value
            End Set
        End Property
        Public Property sContoCorrente() As String
            Get
                Return _sContoCorrente
            End Get
            Set(ByVal Value As String)
                _sContoCorrente = Value
            End Set
        End Property
        Public Property sTipoBollettino() As String
            Get
                Return _sTipoBollettino
            End Get
            Set(ByVal Value As String)
                _sTipoBollettino = Value
            End Set
        End Property
        Public Property sTipoScarto() As String
            Get
                Return _sTipoScarto
            End Get
            Set(ByVal Value As String)
                _sTipoScarto = Value
            End Set
        End Property
    End Class

    <Serializable()>
    Public Class ObjFlussoPagamenti
        Private _nID As Integer = -1
        Private _nIDImport As Integer = -1
        Private _nRcAcquisiti As Integer = 0
        Private _nPagamentiEsatti As Integer = 0
        Private _nPagamentiErrati As Integer = 0
        Private _sIDEnte As String = ""
        Private _sFileAcq As String = ""
        Private _sProvenienza As String = ""
        Private _sDivisa As String = "E"
        Private _sCodCUAS As String = ""
        Private _sContoCorrente As String = ""
        Private _sOperatore As String = ""
        Private _impAcquisiti As Double = 0
        Private _impPagamentiEsatti As Double = 0
        Private _impPagamentiErrati As Double = 0
        Private _tDataAcq As Date = DateTime.MaxValue

        Public Property ID() As Integer
            Get
                Return _nID
            End Get
            Set(ByVal Value As Integer)
                _nID = Value
            End Set
        End Property
        Public Property IDImportazione() As Integer
            Get
                Return _nIDImport
            End Get
            Set(ByVal Value As Integer)
                _nIDImport = Value
            End Set
        End Property
        Public Property nRcAcquisiti() As Integer
            Get
                Return _nRcAcquisiti
            End Get
            Set(ByVal Value As Integer)
                _nRcAcquisiti = Value
            End Set
        End Property
        Public Property nPagamentiEsatti() As Integer
            Get
                Return _nPagamentiEsatti
            End Get
            Set(ByVal Value As Integer)
                _nPagamentiEsatti = Value
            End Set
        End Property
        Public Property nPagamentiErrati() As Integer
            Get
                Return _nPagamentiErrati
            End Get
            Set(ByVal Value As Integer)
                _nPagamentiErrati = Value
            End Set
        End Property
        Public Property IDEnte() As String
            Get
                Return _sIDEnte
            End Get
            Set(ByVal Value As String)
                _sIDEnte = Value
            End Set
        End Property
        Public Property sFileAcq() As String
            Get
                Return _sFileAcq
            End Get
            Set(ByVal Value As String)
                _sFileAcq = Value
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
        Public Property sDivisa() As String
            Get
                Return _sDivisa
            End Get
            Set(ByVal Value As String)
                _sDivisa = Value
            End Set
        End Property
        Public Property sCodCUAS() As String
            Get
                Return _sCodCUAS
            End Get
            Set(ByVal Value As String)
                _sCodCUAS = Value
            End Set
        End Property
        Public Property sContoCorrente() As String
            Get
                Return _sContoCorrente
            End Get
            Set(ByVal Value As String)
                _sContoCorrente = Value
            End Set
        End Property
        Public Property sOperatore() As String
            Get
                Return _sOperatore
            End Get
            Set(ByVal Value As String)
                _sOperatore = Value
            End Set
        End Property
        Public Property impAcquisiti() As Double
            Get
                Return _impAcquisiti
            End Get
            Set(ByVal Value As Double)
                _impAcquisiti = Value
            End Set
        End Property
        Public Property impPagamentiEsatti() As Double
            Get
                Return _impPagamentiEsatti
            End Get
            Set(ByVal Value As Double)
                _impPagamentiEsatti = Value
            End Set
        End Property
        Public Property impPagamentiErrati() As Double
            Get
                Return _impPagamentiErrati
            End Get
            Set(ByVal Value As Double)
                _impPagamentiErrati = Value
            End Set
        End Property
        Public Property tDataAcq() As Date
            Get
                Return _tDataAcq
            End Get
            Set(ByVal Value As Date)
                _tDataAcq = Value
            End Set
        End Property
    End Class

    <Serializable()>
    Public Class ObjDettaglioPagamento
        Private _nId As Integer = -1
        Private _nIdPagamento As Integer = -1
        Private _sNumeroAvviso As String = ""
        Private _sAnno As String = ""
        Private _sCodCapitolo As String = ""
        Private _sCodVoce As String = ""
        Private _sDivisa As String = "E"
        Private _sSegno As String = "+"
        Private _sOperatore As String = ""
        Private _dImpDettaglio As Double
        Private _tDataInsert As Date = Now

        Public Property ID() As Integer
            Get
                Return _nId
            End Get
            Set(ByVal Value As Integer)
                _nId = Value
            End Set
        End Property
        Public Property IDPagamento() As Integer
            Get
                Return _nIdPagamento
            End Get
            Set(ByVal Value As Integer)
                _nIdPagamento = Value
            End Set
        End Property
        Public Property sNumeroAvviso() As String
            Get
                Return _sNumeroAvviso
            End Get
            Set(ByVal Value As String)
                _sNumeroAvviso = Value
            End Set
        End Property
        Public Property sAnno() As String
            Get
                Return _sAnno
            End Get
            Set(ByVal Value As String)
                _sAnno = Value
            End Set
        End Property
        Public Property sCodCapitolo() As String
            Get
                Return _sCodCapitolo
            End Get
            Set(ByVal Value As String)
                _sCodCapitolo = Value
            End Set
        End Property
        Public Property sCodVoce() As String
            Get
                Return _sCodVoce
            End Get
            Set(ByVal Value As String)
                _sCodVoce = Value
            End Set
        End Property
        Public Property sDivisa() As String
            Get
                Return _sDivisa
            End Get
            Set(ByVal Value As String)
                _sDivisa = Value
            End Set
        End Property
        Public Property sSegno() As String
            Get
                Return _sSegno
            End Get
            Set(ByVal Value As String)
                _sSegno = Value
            End Set
        End Property
        Public Property sOperatore() As String
            Get
                Return _sOperatore
            End Get
            Set(ByVal Value As String)
                _sOperatore = Value
            End Set
        End Property
        Public Property dImpDettaglio() As Double
            Get
                Return _dImpDettaglio
            End Get
            Set(ByVal Value As Double)
                _dImpDettaglio = Value
            End Set
        End Property
        Public Property tDataInsert() As Date
            Get
                Return _tDataInsert
            End Get
            Set(ByVal Value As Date)
                _tDataInsert = Value
            End Set
        End Property
    End Class
End Namespace
