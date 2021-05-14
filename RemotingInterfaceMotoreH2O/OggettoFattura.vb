Imports AnagInterface

Namespace MotoreH2o.Oggetti
    <Serializable()>
    Public Class oDettaglioAliquote
        Private _nAliquota As Double = 0
        Private _impBase As Double = 0

        Public Property nALiquota() As Double
            Get
                Return _nAliquota
            End Get
            Set(ByVal Value As Double)
                _nAliquota = Value
            End Set
        End Property
        Public Property impBase() As Double
            Get
                Return _impBase
            End Get
            Set(ByVal Value As Double)
                _impBase = Value
            End Set
        End Property
    End Class

    <Serializable()>
    Public Class ObjFattura
        Public Sub New()
        End Sub

        Private _Id As Long = -1
        Private _sIdEnte As String = ""
        Private _nIdFlusso As Integer = -1
        Private _nIdPeriodo As Integer = -1
        Private _sTipoDocumento As String = ""
        Private _sDescrTipoDocumento As String = ""
        Private _sAnno As String = ""
        Private _nIdContatore As Integer = -1
        Private _nIdIntestatario As Integer = -1
        Private _nIdUtente As Integer = -1
        Private _sNUtente As String = ""
        Private _oAnagrafeIntestatario As DettaglioAnagrafica = Nothing
        Private _oAnagrafeUtente As DettaglioAnagrafica = Nothing
        Private _sViaContatore As String = ""
        Private _sCivicoContatore As String = ""
        Private _sFrazioneContatore As String = ""
        Private _sMatricola As String = ""
        Private _tDataLetturaPrec As Date = DateTime.MaxValue
        Private _nLetturaPrec As Integer = 0
        Private _tDataLetturaAtt As Date = DateTime.MaxValue
        Private _nLetturaAtt As Integer = 0
        Private _nConsumo As Integer = -1
        Private _nGiorni As Integer = -1
        Private _nUtenze As Integer = 0
        Private _nTipoUtenza As Integer = 0
        Private _sDescrTipoUtenza As String = ""
        Private _nTipoContatore As Integer = 0
        Private _sDescrTipoContatore As String = ""
        Private _nCodFognatura As Integer = 0
        Private _nCodDepurazione As Integer = 0
        Private _bEsenteAcqua As Boolean = False
        Private _bEsenteFognatura As Boolean = False
        Private _bEsenteDepurazione As Boolean = False
        Private _tDataDocumento As Date = DateTime.MaxValue
        Private _sNDocumento As String = ""
        Private _sPeriodo As String = ""
        Private _impScaglioni As Double = 0
        Private _impCanoni As Double = 0
        Private _impAddizionali As Double = 0
        Private _impNolo As Double = 0
        Private _impQuoteFisse As Double = 0
        '*** 20121217 - calcolo quota fissa acqua+depurazione+fognatura ***
        Private _bEsenteAcquaQF As Boolean = False
        Private _bEsenteDepQF As Boolean = False
        Private _bEsenteFogQF As Boolean = False
        Private _impQuoteFisseDep As Double = 0
        Private _impQuoteFisseFog As Double = 0
        '*** ***
        Private _impImponibile As Double = 0
        Private _impEsente As Double = 0
        Private _impIva As Double = 0
        Private _impTotale As Double = 0
        Private _impArrotondamento As Double = 0
        Private _impFattura As Double = 0
        Private _oScaglioni() As ObjTariffeScaglione = Nothing
        Private _oCanoni() As ObjTariffeCanone = Nothing
        Private _oAddizionali() As ObjTariffeAddizionale = Nothing
        Private _oNolo() As ObjTariffeNolo = Nothing
        Private _oQuoteFisse() As ObjTariffeQuotaFissa = Nothing
        Private _oDettaglioIva() As ObjDettaglioIva = Nothing
        Private _oLetture() As ObjLettura = Nothing
        Private _tDataDocumentoRif As Date = DateTime.MaxValue
        Private _sNDocumentoRif As String = ""
        Private _tDataInserimento As date=now
        Private _tDataVariazione As Date = DateTime.MaxValue
        Private _tDataCessazione As Date = DateTime.MaxValue
        Private _sOperatore As String = ""

        Public Property Id() As Long
            Get
                Return _Id
            End Get
            Set(ByVal Value As Long)
                _Id = Value
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
        Public Property nIdFlusso() As Integer
            Get
                Return _nIdFlusso
            End Get
            Set(ByVal Value As Integer)
                _nIdFlusso = Value
            End Set
        End Property
        Public Property nIdPeriodo() As Integer
            Get
                Return _nIdPeriodo
            End Get
            Set(ByVal Value As Integer)
                _nIdPeriodo = Value
            End Set
        End Property
        Public Property sTipoDocumento() As String
            Get
                Return _sTipoDocumento
            End Get
            Set(ByVal Value As String)
                _sTipoDocumento = Value
            End Set
        End Property
        Public Property sDescrTipoDocumento() As String
            Get
                Return _sDescrTipoDocumento
            End Get
            Set(ByVal Value As String)
                _sDescrTipoDocumento = Value
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
        Public Property nIdContatore() As Integer
            Get
                Return _nIdContatore
            End Get
            Set(ByVal Value As Integer)
                _nIdContatore = Value
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
        Public Property sNUtente() As String
            Get
                Return _sNUtente
            End Get
            Set(ByVal Value As String)
                _sNUtente = Value
            End Set
        End Property
        Public Property oAnagrafeIntestatario() As DettaglioAnagrafica
            Get
                Return _oAnagrafeIntestatario
            End Get
            Set(ByVal Value As DettaglioAnagrafica)
                _oAnagrafeIntestatario = Value
            End Set
        End Property
        Public Property oAnagrafeUtente() As DettaglioAnagrafica
            Get
                Return _oAnagrafeUtente
            End Get
            Set(ByVal Value As DettaglioAnagrafica)
                _oAnagrafeUtente = Value
            End Set
        End Property
        Public Property sViaContatore() As String
            Get
                Return _sViaContatore
            End Get
            Set(ByVal Value As String)
                _sViaContatore = Value
            End Set
        End Property
        Public Property sCivicoContatore() As String
            Get
                Return _sCivicoContatore
            End Get
            Set(ByVal Value As String)
                _sCivicoContatore = Value
            End Set
        End Property
        Public Property sFrazioneContatore() As String
            Get
                Return _sFrazioneContatore
            End Get
            Set(ByVal Value As String)
                _sFrazioneContatore = Value
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
        Public Property tDataLetturaPrec() As Date
            Get
                Return _tDataLetturaPrec
            End Get
            Set(ByVal Value As Date)
                _tDataLetturaPrec = Value
            End Set
        End Property
        Public Property nLetturaPrec() As Integer
            Get
                Return _nLetturaPrec
            End Get
            Set(ByVal Value As Integer)
                _nLetturaPrec = Value
            End Set
        End Property
        Public Property tDataLetturaAtt() As Date
            Get
                Return _tDataLetturaAtt
            End Get
            Set(ByVal Value As Date)
                _tDataLetturaAtt = Value
            End Set
        End Property
        Public Property nLetturaAtt() As Integer
            Get
                Return _nLetturaAtt
            End Get
            Set(ByVal Value As Integer)
                _nLetturaAtt = Value
            End Set
        End Property
        Public Property nConsumo() As Integer
            Get
                Return _nConsumo
            End Get
            Set(ByVal Value As Integer)
                _nConsumo = Value
            End Set
        End Property
        Public Property nGiorni() As Integer
            Get
                Return _nGiorni
            End Get
            Set(ByVal Value As Integer)
                _nGiorni = Value
            End Set
        End Property
        Public Property nUtenze() As Integer
            Get
                Return _nUtenze
            End Get
            Set(ByVal Value As Integer)
                _nUtenze = Value
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
        Public Property sDescrTipoUtenza() As String
            Get
                Return _sDescrTipoUtenza
            End Get
            Set(ByVal Value As String)
                _sDescrTipoUtenza = Value
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
        Public Property sDescrTipoContatore() As String
            Get
                Return _sDescrTipoContatore
            End Get
            Set(ByVal Value As String)
                _sDescrTipoContatore = Value
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
        Public Property nCodDepurazione() As Integer
            Get
                Return _nCodDepurazione
            End Get
            Set(ByVal Value As Integer)
                _nCodDepurazione = Value
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
        Public Property bEsenteFognatura() As Boolean
            Get
                Return _bEsenteFognatura
            End Get
            Set(ByVal Value As Boolean)
                _bEsenteFognatura = Value
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
        Public Property tDataDocumento() As Date
            Get
                Return _tDataDocumento
            End Get
            Set(ByVal Value As Date)
                _tDataDocumento = Value
            End Set
        End Property
        Public Property sNDocumento() As String
            Get
                Return _sNDocumento
            End Get
            Set(ByVal Value As String)
                _sNDocumento = Value
            End Set
        End Property
        Public Property sPeriodo() As String
            Get
                Return _sPeriodo
            End Get
            Set(ByVal Value As String)
                _sPeriodo = Value
            End Set
        End Property
        Public Property impScaglioni() As Double
            Get
                Return _impScaglioni
            End Get
            Set(ByVal Value As Double)
                _impScaglioni = Value
            End Set
        End Property
        Public Property impCanoni() As Double
            Get
                Return _impCanoni
            End Get
            Set(ByVal Value As Double)
                _impCanoni = Value
            End Set
        End Property
        Public Property impAddizionali() As Double
            Get
                Return _impAddizionali
            End Get
            Set(ByVal Value As Double)
                _impAddizionali = Value
            End Set
        End Property
        Public Property impNolo() As Double
            Get
                Return _impNolo
            End Get
            Set(ByVal Value As Double)
                _impNolo = Value
            End Set
        End Property
        Public Property impQuoteFisse() As Double
            Get
                Return _impQuoteFisse
            End Get
            Set(ByVal Value As Double)
                _impQuoteFisse = Value
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
        Public Property bEsenteFogQF() As Boolean
            Get
                Return _bEsenteFogQF
            End Get
            Set(ByVal Value As Boolean)
                _bEsenteFogQF = Value
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
        Public Property impQuoteFisseDep() As Double
            Get
                Return _impQuoteFisseDep
            End Get
            Set(ByVal Value As Double)
                _impQuoteFisseDep = Value
            End Set
        End Property
        Public Property impQuoteFisseFog() As Double
            Get
                Return _impQuoteFisseFog
            End Get
            Set(ByVal Value As Double)
                _impQuoteFisseFog = Value
            End Set
        End Property
        '*** ***
        Public Property impImponibile() As Double
            Get
                Return _impImponibile
            End Get
            Set(ByVal Value As Double)
                _impImponibile = Value
            End Set
        End Property
        Public Property impEsente() As Double
            Get
                Return _impEsente
            End Get
            Set(ByVal Value As Double)
                _impEsente = Value
            End Set
        End Property
        Public Property impIva() As Double
            Get
                Return _impIva
            End Get
            Set(ByVal Value As Double)
                _impIva = Value
            End Set
        End Property
        Public Property impTotale() As Double
            Get
                Return _impTotale
            End Get
            Set(ByVal Value As Double)
                _impTotale = Value
            End Set
        End Property
        Public Property impArrotondamento() As Double
            Get
                Return _impArrotondamento
            End Get
            Set(ByVal Value As Double)
                _impArrotondamento = Value
            End Set
        End Property
        Public Property impFattura() As Double
            Get
                Return _impFattura
            End Get
            Set(ByVal Value As Double)
                _impFattura = Value
            End Set
        End Property
        Public Property oScaglioni() As ObjTariffeScaglione()
            Get
                Return _oScaglioni
            End Get
            Set(ByVal Value As ObjTariffeScaglione())
                _oScaglioni = Value
            End Set
        End Property
        Public Property oCanoni() As ObjTariffeCanone()
            Get
                Return _oCanoni
            End Get
            Set(ByVal Value As ObjTariffeCanone())
                _oCanoni = Value
            End Set
        End Property
        Public Property oAddizionali() As ObjTariffeAddizionale()
            Get
                Return _oAddizionali
            End Get
            Set(ByVal Value As ObjTariffeAddizionale())
                _oAddizionali = Value
            End Set
        End Property
        Public Property oNolo() As ObjTariffeNolo()
            Get
                Return _oNolo
            End Get
            Set(ByVal Value As ObjTariffeNolo())
                _oNolo = Value
            End Set
        End Property
        Public Property oQuoteFisse() As ObjTariffeQuotaFissa()
            Get
                Return _oQuoteFisse
            End Get
            Set(ByVal Value As ObjTariffeQuotaFissa())
                _oQuoteFisse = Value
            End Set
        End Property
        Public Property oDettaglioIva() As ObjDettaglioIva()
            Get
                Return _oDettaglioIva
            End Get
            Set(ByVal Value As ObjDettaglioIva())
                _oDettaglioIva = Value
            End Set
        End Property
        Public Property oLetture() As ObjLettura()
            Get
                Return _oLetture
            End Get
            Set(ByVal Value As ObjLettura())
                _oLetture = Value
            End Set
        End Property
        Public Property tDataDocumentoRif() As Date
            Get
                Return _tDataDocumentoRif
            End Get
            Set(ByVal Value As Date)
                _tDataDocumentoRif = Value
            End Set
        End Property
        Public Property sNDocumentoRif() As String
            Get
                Return _sNDocumentoRif
            End Get
            Set(ByVal Value As String)
                _sNDocumentoRif = Value
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
        Public Property tDataCessazione() As Date
            Get
                Return _tDataCessazione
            End Get
            Set(ByVal Value As Date)
                _tDataCessazione = Value
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
    Public Class objVariazioneFattura
        Private _Id As Long
        Private _sIdEnte As String
        Private _nIdPeriodo As Integer
        Private _nIdContatore As Integer
        Private _nIdLettura As Integer
        Private _nIdIntestatario As Integer
        Private _nIdUtente As Integer
        Private _nUtenze As Integer
        Private _nTipoUtenza As Integer
        Private _nTipoContatore As Integer
        Private _nCodFognatura As Integer
        Private _nCodDepurazione As Integer
        Private _bEsenteAcqua As Boolean
        Private _bEsenteFognatura As Boolean
        Private _bEsenteDepurazione As Boolean
        Private _bNoloUnaTantum As Boolean
        '*** 20121217 - calcolo quota fissa acqua+depurazione+fognatura ***
        Private _bEsenteAcquaQF As Boolean = False
        Private _bEsenteDepQF As Boolean = False
        Private _bEsenteFogQF As Boolean = False
        '*** ***
        Private _tDataLetturaPrec As Date
        Private _nLetturaPrec As Integer
        Private _tDataLetturaAtt As Date
        Private _nLetturaAtt As Integer
        Private _nConsumo As Integer
        Private _nGiorni As Integer
        '*** 20130110 - devo prelevare anche la data lettura orginale perchè posso variarla di conseguenza non troverei più la lettura da aggiornare ***
        Private _tDataLetturaAttOrg As Date
        '*** ***
        Private _oFattura As ObjFattura
        Private _tDataInserimento As Date
        Private _tDataVariazione As Date
        Private _sAzione As String

        Public Property Id() As Long
            Get
                Return _Id
            End Get
            Set(ByVal Value As Long)
                _Id = Value
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
        Public Property nIdPeriodo() As Integer
            Get
                Return _nIdPeriodo
            End Get
            Set(ByVal Value As Integer)
                _nIdPeriodo = Value
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
        Public Property nIdLettura() As Integer
            Get
                Return _nIdLettura
            End Get
            Set(ByVal Value As Integer)
                _nIdLettura = Value
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
        Public Property nConsumo() As Integer
            Get
                Return _nConsumo
            End Get
            Set(ByVal Value As Integer)
                _nConsumo = Value
            End Set
        End Property
        Public Property nGiorni() As Integer
            Get
                Return _nGiorni
            End Get
            Set(ByVal Value As Integer)
                _nGiorni = Value
            End Set
        End Property
        Public Property nUtenze() As Integer
            Get
                Return _nUtenze
            End Get
            Set(ByVal Value As Integer)
                _nUtenze = Value
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
        Public Property nCodFognatura() As Integer
            Get
                Return _nCodFognatura
            End Get
            Set(ByVal Value As Integer)
                _nCodFognatura = Value
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
        Public Property bEsenteAcqua() As Boolean
            Get
                Return _bEsenteAcqua
            End Get
            Set(ByVal Value As Boolean)
                _bEsenteAcqua = Value
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
        Public Property bEsenteDepurazione() As Boolean
            Get
                Return _bEsenteDepurazione
            End Get
            Set(ByVal Value As Boolean)
                _bEsenteDepurazione = Value
            End Set
        End Property
        Public Property bNoloUnaTantum() As Boolean
            Get
                Return _bNoloUnaTantum
            End Get
            Set(ByVal Value As Boolean)
                _bNoloUnaTantum = Value
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
        Public Property bEsenteFogQF() As Boolean
            Get
                Return _bEsenteFogQF
            End Get
            Set(ByVal Value As Boolean)
                _bEsenteFogQF = Value
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
        '*** ***
        Public Property tDataLetturaPrec() As Date
            Get
                Return _tDataLetturaPrec
            End Get
            Set(ByVal Value As Date)
                _tDataLetturaPrec = Value
            End Set
        End Property
        Public Property nLetturaPrec() As Integer
            Get
                Return _nLetturaPrec
            End Get
            Set(ByVal Value As Integer)
                _nLetturaPrec = Value
            End Set
        End Property
        Public Property tDataLetturaAtt() As Date
            Get
                Return _tDataLetturaAtt
            End Get
            Set(ByVal Value As Date)
                _tDataLetturaAtt = Value
            End Set
        End Property
        Public Property nLetturaAtt() As Integer
            Get
                Return _nLetturaAtt
            End Get
            Set(ByVal Value As Integer)
                _nLetturaAtt = Value
            End Set
        End Property
        '*** 20130110 - devo prelevare anche la data lettura orginale perchè posso variarla di conseguenza non troverei più la lettura da aggiornare ***
        Public Property tDataLetturaAttOrg() As Date
            Get
                Return _tDataLetturaAttOrg
            End Get
            Set(ByVal Value As Date)
                _tDataLetturaAttOrg = Value
            End Set
        End Property
        '*** ***
        Public Property oFattura() As ObjFattura
            Get
                Return _oFattura
            End Get
            Set(ByVal Value As ObjFattura)
                _oFattura = Value
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
        Public Property sAzione() As String
            Get
                Return _sAzione
            End Get
            Set(ByVal Value As String)
                _sAzione = Value
            End Set
        End Property

        Public Sub New()
            Id = -1
            sIdEnte = ""
            nIdPeriodo = -1
            nIdContatore = -1
            nIdLettura = -1
            nIdIntestatario = -1
            nIdUtente = -1
            nUtenze = 0
            nTipoUtenza = 0
            nTipoContatore = 0
            nCodFognatura = 0
            nCodDepurazione = 0
            bEsenteAcqua = False
            bEsenteFognatura = False
            bEsenteDepurazione = False
            bNoloUnaTantum = False
            tDataLetturaPrec = DateTime.MaxValue
            nLetturaPrec = 0
            tDataLetturaAtt = DateTime.MaxValue
            nLetturaAtt = 0
            nConsumo = -1
            nGiorni = -1
            oFattura = Nothing
            tdatainserimento=now
            tDataVariazione = DateTime.MaxValue
            sAzione = ""
        End Sub
    End Class

    <Serializable()>
    Public Class objRicercaVariazione
        Private _nIdVariazione As Long
        Private _sIdEnte As String
        Private _sPeriodo As String
        Private _sNomeIntestatario As String
        Private _sNomeUtente As String
        Private _sMatricola As String
        Private _sVarContatore As String
        Private _sVarLettura As String
        Private _bIsSel As Boolean
        Private _tDataInserimento As Date
        Private _tDataVariazione As Date
        Private _sAzione As String

        Public Property nIdVariazione() As Long
            Get
                Return _nIdVariazione
            End Get
            Set(ByVal Value As Long)
                _nIdVariazione = Value
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
        Public Property sPeriodo() As String
            Get
                Return _sPeriodo
            End Get
            Set(ByVal Value As String)
                _sPeriodo = Value
            End Set
        End Property
        Public Property sNomeIntestatario() As String
            Get
                Return _sNomeIntestatario
            End Get
            Set(ByVal Value As String)
                _sNomeIntestatario = Value
            End Set
        End Property
        Public Property sNomeUtente() As String
            Get
                Return _sNomeUtente
            End Get
            Set(ByVal Value As String)
                _sNomeUtente = Value
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
        Public Property sVarContatore() As String
            Get
                Return _sVarContatore
            End Get
            Set(ByVal Value As String)
                _sVarContatore = Value
            End Set
        End Property
        Public Property sVarLettura() As String
            Get
                Return _sVarLettura
            End Get
            Set(ByVal Value As String)
                _sVarLettura = Value
            End Set
        End Property
        Public Property bIsSel() As Boolean
            Get
                Return _bIsSel
            End Get
            Set(ByVal Value As Boolean)
                _bIsSel = Value
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
        Public Property sAzione() As String
            Get
                Return _sAzione
            End Get
            Set(ByVal Value As String)
                _sAzione = Value
            End Set
        End Property

        Public Sub New()
            nIdVariazione = -1
            sIdEnte = ""
            sPeriodo = ""
            sNomeIntestatario = ""
            sNomeUtente = ""
            sMatricola = ""
            sVarContatore = ""
            sVarLettura = ""
            bIsSel = False
            tdatainserimento=now
            tDataVariazione = DateTime.MaxValue
            sAzione = ""
        End Sub
    End Class
End Namespace
