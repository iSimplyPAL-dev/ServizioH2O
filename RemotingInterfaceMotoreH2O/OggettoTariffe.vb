Namespace MotoreH2o.Oggetti
    <Serializable()> _
Public Class ObjTariffe
        Public Sub New()
        End Sub

        Private _oScaglioni() As OggettoScaglione = Nothing
        Private _oCanoni() As OggettoCanone = Nothing
        Private _oAddizionali() As OggettoAddizionaleEnte = Nothing
        Private _oNolo() As OggettoNoloContatore = Nothing
        Private _oQuoteFisse() As OggettoQuotaFissa = Nothing

        Public Property oScaglioni() As OggettoScaglione()
            Get
                Return _oScaglioni
            End Get
            Set(ByVal Value As OggettoScaglione())
                _oScaglioni = Value
            End Set
        End Property
        Public Property oCanoni() As OggettoCanone()
            Get
                Return _oCanoni
            End Get
            Set(ByVal Value As OggettoCanone())
                _oCanoni = Value
            End Set
        End Property
        Public Property oAddizionali() As OggettoAddizionaleEnte()
            Get
                Return _oAddizionali
            End Get
            Set(ByVal Value As OggettoAddizionaleEnte())
                _oAddizionali = Value
            End Set
        End Property
        Public Property oNolo() As OggettoNoloContatore()
            Get
                Return _oNolo
            End Get
            Set(ByVal Value As OggettoNoloContatore())
                _oNolo = Value
            End Set
        End Property
        Public Property oQuoteFisse() As OggettoQuotaFissa()
            Get
                Return _oQuoteFisse
            End Get
            Set(ByVal Value As OggettoQuotaFissa())
                _oQuoteFisse = Value
            End Set
        End Property
    End Class

    <Serializable()> _
  Public Class ObjTariffeScaglione
        Public Sub New()
        End Sub

        Private _Id As Long = -1
        Private _nIdFattura As Long = -1
        Private _IdLettura As Integer = -1
        Private _sIdEnte As String = ""
        Private _sAnno As String = ""
        Private _nIdScaglione As Integer = -1
        Private _nDa As Integer = -1
        Private _nA As Integer = -1
        Private _nQuantita As Integer = -1
        Private _impTariffa As Double = 0
        Private _impMinimo As Double = 0
        Private _nAliquota As Double = 0
        Private _impScaglione As Double = 0
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
        Public Property nIdFattura() As Long
            Get
                Return _nIdFattura
            End Get
            Set(ByVal Value As Long)
                _nIdFattura = Value
            End Set
        End Property
        Public Property nIdLettura() As Integer
            Get
                Return _IdLettura
            End Get
            Set(ByVal Value As Integer)
                _IdLettura = Value
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
        Public Property sAnno() As String
            Get
                Return _sAnno
            End Get
            Set(ByVal Value As String)
                _sAnno = Value
            End Set
        End Property
        Public Property nIdScaglione() As Integer
            Get
                Return _nIdScaglione
            End Get
            Set(ByVal Value As Integer)
                _nIdScaglione = Value
            End Set
        End Property
        Public Property nDa() As Integer
            Get
                Return _nDa
            End Get
            Set(ByVal Value As Integer)
                _nDa = Value
            End Set
        End Property
        Public Property nA() As Integer
            Get
                Return _nA
            End Get
            Set(ByVal Value As Integer)
                _nA = Value
            End Set
        End Property
        Public Property nQuantita() As Integer
            Get
                Return _nQuantita
            End Get
            Set(ByVal Value As Integer)
                _nQuantita = Value
            End Set
        End Property
        Public Property impTariffa() As Double
            Get
                Return _impTariffa
            End Get
            Set(ByVal Value As Double)
                _impTariffa = Value
            End Set
        End Property
        Public Property impMinimo() As Double
            Get
                Return _impMinimo
            End Get
            Set(ByVal Value As Double)
                _impMinimo = Value
            End Set
        End Property
        Public Property nAliquota() As Double
            Get
                Return _nAliquota
            End Get
            Set(ByVal Value As Double)
                _nAliquota = Value
            End Set
        End Property
        Public Property impScaglione() As Double
            Get
                Return _impScaglione
            End Get
            Set(ByVal Value As Double)
                _impScaglione = Value
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

    <Serializable()> _
    Public Class ObjTariffeCanone
        Public Sub New()
        End Sub

        Private _Id As Long = -1
        Private _nIdFattura As Long = -1
        Private _IdLettura As Integer = -1
        Private _sIdEnte As String = ""
        Private _sAnno As String = ""
        Private _sDescrizione As String = ""
        Private _impTariffa As Double = 0
        Private _nPercentSulConsumo As Double = 0
        Private _nIdCanone As Integer = -1
        Private _nAliquota As Double = 0
        Private _impCanone As Double = 0
        Private _tDataInserimento As date=now
        Private _tDataVariazione As Date = DateTime.MaxValue
        Private _tDataCessazione As Date = DateTime.MaxValue
        Private _sOperatore As String = ""
        '*** 20141125 - Componente aggiuntiva sui consumi ***
        Private _idServizio As Integer
        Private _idTipoCanone As Integer
        '*** ***

        Public Property Id() As Long
            Get
                Return _Id
            End Get
            Set(ByVal Value As Long)
                _Id = Value
            End Set
        End Property
        Public Property nIdFattura() As Long
            Get
                Return _nIdFattura
            End Get
            Set(ByVal Value As Long)
                _nIdFattura = Value
            End Set
        End Property
        Public Property nIdLettura() As Integer
            Get
                Return _IdLettura
            End Get
            Set(ByVal Value As Integer)
                _IdLettura = Value
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
        Public Property nIdCanone() As Integer
            Get
                Return _nIdCanone
            End Get
            Set(ByVal Value As Integer)
                _nIdCanone = Value
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
        Public Property sDescrizione() As String
            Get
                Return _sDescrizione
            End Get
            Set(ByVal Value As String)
                _sDescrizione = Value
            End Set
        End Property
        Public Property impTariffa() As Double
            Get
                Return _impTariffa
            End Get
            Set(ByVal Value As Double)
                _impTariffa = Value
            End Set
        End Property
        Public Property nPercentSulConsumo() As Double
            Get
                Return _nPercentSulConsumo
            End Get
            Set(ByVal Value As Double)
                _nPercentSulConsumo = Value
            End Set
        End Property
        Public Property nAliquota() As Double
            Get
                Return _nAliquota
            End Get
            Set(ByVal Value As Double)
                _nAliquota = Value
            End Set
        End Property
        Public Property impCanone() As Double
            Get
                Return _impCanone
            End Get
            Set(ByVal Value As Double)
                _impCanone = Value
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
        '*** 20141125 - Componente aggiuntiva sui consumi ***
        Public Property idServizio() As Integer
            Get
                Return _idServizio
            End Get
            Set(ByVal Value As Integer)
                _idServizio = Value
            End Set
        End Property
        Public Property idTipoCanone() As Integer
            Get
                Return _idTipoCanone
            End Get
            Set(ByVal Value As Integer)
                _idTipoCanone = Value
            End Set
        End Property
        '*** ***
    End Class

    <Serializable()> _
  Public Class ObjTariffeAddizionale
        Public Sub New()
        End Sub

        Private _Id As Long = -1
        Private _nIdFattura As Long = -1
        Private _IdLettura As Integer = -1
        Private _sIdEnte As String = ""
        Private _sAnno As String = ""
        Private _nIdAddizionale As Integer = -1
        Private _sDescrizione As String = ""
        Private _impTariffa As Double = 0
        Private _nAliquota As Double = 0
        Private _impAddizionale As Double = 0
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
        Public Property nIdFattura() As Long
            Get
                Return _nIdFattura
            End Get
            Set(ByVal Value As Long)
                _nIdFattura = Value
            End Set
        End Property
        Public Property nIdLettura() As Integer
            Get
                Return _IdLettura
            End Get
            Set(ByVal Value As Integer)
                _IdLettura = Value
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
        Public Property sAnno() As String
            Get
                Return _sAnno
            End Get
            Set(ByVal Value As String)
                _sAnno = Value
            End Set
        End Property
        Public Property nIdAddizionale() As Integer
            Get
                Return _nIdAddizionale
            End Get
            Set(ByVal Value As Integer)
                _nIdAddizionale = Value
            End Set
        End Property
        Public Property sDescrizione() As String
            Get
                Return _sDescrizione
            End Get
            Set(ByVal Value As String)
                _sDescrizione = Value
            End Set
        End Property
        Public Property impTariffa() As Double
            Get
                Return _impTariffa
            End Get
            Set(ByVal Value As Double)
                _impTariffa = Value
            End Set
        End Property
        Public Property nAliquota() As Double
            Get
                Return _nAliquota
            End Get
            Set(ByVal Value As Double)
                _nAliquota = Value
            End Set
        End Property
        Public Property impAddizionale() As Double
            Get
                Return _impAddizionale
            End Get
            Set(ByVal Value As Double)
                _impAddizionale = Value
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

    <Serializable()> _
  Public Class ObjTariffeQuotaFissa
        Public Sub New()
        End Sub

        Private _Id As Long = -1
        Private _nIdFattura As Long = -1
        Private _IdLettura As Integer = -1
        Private _sIdEnte As String = ""
        Private _sAnno As String = ""
        Private _nIdQuotaFissa As Integer = -1
        Private _nDa As Integer = -1
        Private _nA As Integer = -1
        Private _impTariffa As Double = 0
        Private _nAliquota As Double = 0
		Private _impQuotaFissa As Double = 0
		'*** 20121217 - calcolo quota fissa acqua+depurazione+fognatura ***
		Private _nIdTipoCanone As Integer = 3
		'*** ***
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
        Public Property nIdFattura() As Long
            Get
                Return _nIdFattura
            End Get
            Set(ByVal Value As Long)
                _nIdFattura = Value
            End Set
        End Property
        Public Property nIdLettura() As Integer
            Get
                Return _IdLettura
            End Get
            Set(ByVal Value As Integer)
                _IdLettura = Value
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
        Public Property sAnno() As String
            Get
                Return _sAnno
            End Get
            Set(ByVal Value As String)
                _sAnno = Value
            End Set
        End Property
        Public Property nIdQuotaFissa() As Integer
            Get
                Return _nIdQuotaFissa
            End Get
            Set(ByVal Value As Integer)
                _nIdQuotaFissa = Value
            End Set
		End Property
		'*** 20121217 - calcolo quota fissa acqua+depurazione+fognatura ***
		Public Property nIdTipoCanone() As Integer
			Get
				Return _nIdTipoCanone
			End Get
			Set(ByVal Value As Integer)
				_nIdTipoCanone = Value
			End Set
		End Property
		'*** ***
		Public Property nDa() As Integer
			Get
				Return _nDa
			End Get
			Set(ByVal Value As Integer)
				_nDa = Value
			End Set
		End Property
		Public Property nA() As Integer
			Get
				Return _nA
			End Get
			Set(ByVal Value As Integer)
				_nA = Value
			End Set
		End Property
		Public Property impTariffa() As Double
			Get
				Return _impTariffa
			End Get
			Set(ByVal Value As Double)
				_impTariffa = Value
			End Set
		End Property
		Public Property nAliquota() As Double
			Get
				Return _nAliquota
			End Get
			Set(ByVal Value As Double)
				_nAliquota = Value
			End Set
		End Property
		Public Property impQuotaFissa() As Double
			Get
				Return _impQuotaFissa
			End Get
			Set(ByVal Value As Double)
				_impQuotaFissa = Value
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

    <Serializable()> _
  Public Class ObjTariffeNolo
        Public Sub New()
        End Sub

        Private _Id As Long = -1
        Private _nIdFattura As Long = -1
        Private _IdLettura As Integer = -1
        Private _sIdEnte As String = ""
        Private _sAnno As String = ""
        Private _nIdNolo As Integer = -1
        Private _nAliquota As Double = 0
        Private _impTariffa As Double = 0
        Private _impNolo As Double = 0
        Private _tDataInserimento As date=now
        Private _tDataVariazione As Date = DateTime.MaxValue
        Private _tDataCessazione As Date = DateTime.MaxValue
        Private _sOperatore As String = ""
        Private _bIsUnaTantum As Boolean = False

        Public Property Id() As Long
            Get
                Return _Id
            End Get
            Set(ByVal Value As Long)
                _Id = Value
            End Set
        End Property
        Public Property nIdFattura() As Long
            Get
                Return _nIdFattura
            End Get
            Set(ByVal Value As Long)
                _nIdFattura = Value
            End Set
        End Property
        Public Property nIdLettura() As Integer
            Get
                Return _IdLettura
            End Get
            Set(ByVal Value As Integer)
                _IdLettura = Value
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
        Public Property sAnno() As String
            Get
                Return _sAnno
            End Get
            Set(ByVal Value As String)
                _sAnno = Value
            End Set
        End Property
        Public Property nIdNolo() As Integer
            Get
                Return _nIdNolo
            End Get
            Set(ByVal Value As Integer)
                _nIdNolo = Value
            End Set
        End Property
        Public Property impTariffa() As Double
            Get
                Return _impTariffa
            End Get
            Set(ByVal Value As Double)
                _impTariffa = Value
            End Set
        End Property
        Public Property nAliquota() As Double
            Get
                Return _nAliquota
            End Get
            Set(ByVal Value As Double)
                _nAliquota = Value
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
        Public Property bIsUnaTantum() As Boolean
            Get
                Return _bIsUnaTantum
            End Get
            Set(ByVal Value As Boolean)
                _bIsUnaTantum = Value
            End Set
        End Property
    End Class
End Namespace
