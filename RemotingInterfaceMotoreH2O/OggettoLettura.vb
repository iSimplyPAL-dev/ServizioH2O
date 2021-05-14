Namespace MotoreH2o.Oggetti
    <Serializable()> _
    Public Class ObjLettura
        Private _IdLettura As Integer
        Private _nIdContatore As Integer
        Private _nIdContatorePrec As Integer
        Private _nIdPeriodo As Integer
        Private _nLetturaAtt As Integer
        Private _nCodModoLett As Integer
        Private _nConsumo As Integer
        Private _nGiorni As Integer
        Private _nConsumoTeorico As Integer
        Private _nLetturaPrec As Integer
        Private _nIdUtente As Integer
        Private _nConsumoPrec As Integer
        Private _nGiorniPrec As Integer
        Private _nIdStatoLettura As Integer
        Private _nIdAnomalia1 As Integer
        Private _nIdAnomalia2 As Integer
        Private _nIdAnomalia3 As Integer
        Private _nTipoArrotondConsumo As Integer
        Private _nConsumoSubContatore As Integer
        Private _tDataLetturaAtt As Date
        Private _tDataLetturaPrec As Date
        Private _tDataFatt As Date
        Private _tDataPassaggio As Date
        Private _tDataInserimento As Date
        Private _tDataVariazione As Date
        Private _bIsFatturata As Boolean
        Private _bIsIncongruente As Boolean
        Private _bIsIncongruenteForzato As Boolean
        Private _bIsPrimaLettura As Boolean
        Private _bIsUltimaLettura As Boolean
        Private _bFattSospesa As Boolean
        Private _bIsGiroContatore As Boolean
        Private _bIsStorica As Boolean
        Private _bIsStoricizzata As Boolean
        Private _sNote As String
        Private _sNUtente As String
        Private _sLetturaTeorica As String
        Private _sProvenienza As String
        Private _sAzione As String

        Public Property IdLettura() As Integer
            Get
                Return _IdLettura
            End Get
            Set(ByVal Value As Integer)
                _IdLettura = Value
            End Set
        End Property
        Public Property nConsumoPrec() As Integer
            Get
                Return _nConsumoPrec
            End Get
            Set(ByVal Value As Integer)
                _nConsumoPrec = Value
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
        Public Property nIdContatore() As Integer
            Get
                Return _nIdContatore
            End Get
            Set(ByVal Value As Integer)
                _nIdContatore = Value
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
        Public Property nIdPeriodo() As Integer
            Get
                Return _nIdPeriodo
            End Get
            Set(ByVal Value As Integer)
                _nIdPeriodo = Value
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
        Public Property sProvenienza() As String
            Get
                Return _sProvenienza
            End Get
            Set(ByVal Value As String)
                _sProvenienza = Value
            End Set
        End Property
        Public Property sLetturaTeorica() As String
            Get
                Return _sLetturaTeorica
            End Get
            Set(ByVal Value As String)
                _sLetturaTeorica = Value
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
        Public Property tDataFatt() As Date
            Get
                Return _tDataFatt
            End Get
            Set(ByVal Value As Date)
                _tDataFatt = Value
            End Set
        End Property
        Public Property tDataPassaggio() As Date
            Get
                Return _tDataPassaggio
            End Get
            Set(ByVal Value As Date)
                _tDataPassaggio = Value
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
        Public Property nConsumoSubContatore() As Integer
            Get
                Return _nConsumoSubContatore
            End Get
            Set(ByVal Value As Integer)
                _nConsumoSubContatore = Value
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
        Public Property nGiorniPrec() As Integer
            Get
                Return _nGiorniPrec
            End Get
            Set(ByVal Value As Integer)
                _nGiorniPrec = Value
            End Set
        End Property
        Public Property nIdAnomalia1() As Integer
            Get
                Return _nIdAnomalia1
            End Get
            Set(ByVal Value As Integer)
                _nIdAnomalia1 = Value
            End Set
        End Property
        Public Property nIdAnomalia2() As Integer
            Get
                Return _nIdAnomalia2
            End Get
            Set(ByVal Value As Integer)
                _nIdAnomalia2 = Value
            End Set
        End Property
        Public Property nIdAnomalia3() As Integer
            Get
                Return _nIdAnomalia3
            End Get
            Set(ByVal Value As Integer)
                _nIdAnomalia3 = Value
            End Set
        End Property
        Public Property nIdStatoLettura() As Integer
            Get
                Return _nIdStatoLettura
            End Get
            Set(ByVal Value As Integer)
                _nIdStatoLettura = Value
            End Set
        End Property
        Public Property nCodModoLett() As Integer
            Get
                Return _nCodModoLett
            End Get
            Set(ByVal Value As Integer)
                _nCodModoLett = Value
            End Set
        End Property
        Public Property nConsumoTeorico() As Integer
            Get
                Return _nConsumoTeorico
            End Get
            Set(ByVal Value As Integer)
                _nConsumoTeorico = Value
            End Set
        End Property
        Public Property bIsFatturata() As Boolean
            Get
                Return _bIsFatturata
            End Get
            Set(ByVal Value As Boolean)
                _bIsFatturata = Value
            End Set
        End Property
        Public Property bIsIncongruente() As Boolean
            Get
                Return _bIsIncongruente
            End Get
            Set(ByVal Value As Boolean)
                _bIsIncongruente = Value
            End Set
        End Property
        Public Property bIsIncongruenteForzato() As Boolean
            Get
                Return _bIsIncongruenteForzato
            End Get
            Set(ByVal Value As Boolean)
                _bIsIncongruenteForzato = Value
            End Set
        End Property
        Public Property bFattSospesa() As Boolean
            Get
                Return _bFattSospesa
            End Get
            Set(ByVal Value As Boolean)
                _bFattSospesa = Value
            End Set
        End Property
        Public Property bIsPrimaLettura() As Boolean
            Get
                Return _bIsPrimaLettura
            End Get
            Set(ByVal Value As Boolean)
                _bIsPrimaLettura = Value
            End Set
        End Property
        Public Property bIsUltimaLettura() As Boolean
            Get
                Return _bIsUltimaLettura
            End Get
            Set(ByVal Value As Boolean)
                _bIsUltimaLettura = Value
            End Set
        End Property
        Public Property nTipoArrotondConsumo() As Integer
            Get
                Return _nTipoArrotondConsumo
            End Get
            Set(ByVal Value As Integer)
                _nTipoArrotondConsumo = Value
            End Set
        End Property
        Public Property bIsGiroContatore() As Boolean
            Get
                Return _bIsGiroContatore
            End Get
            Set(ByVal Value As Boolean)
                _bIsGiroContatore = Value
            End Set
        End Property
        Public Property bIsStorica() As Boolean
            Get
                Return _bIsStorica
            End Get
            Set(ByVal Value As Boolean)
                _bIsStorica = Value
            End Set
        End Property
        Public Property bIsStoricizzata() As Boolean
            Get
                Return _bIsStoricizzata
            End Get
            Set(ByVal Value As Boolean)
                _bIsStoricizzata = Value
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

        Public Sub New()
            IdLettura = -1
            nIdContatore = -1
            nIdContatorePrec = -1
            nIdPeriodo = -1
            tDataLetturaAtt = DateTime.MaxValue
            nLetturaAtt = 0
            nCodModoLett = 0
            bIsFatturata = False
            nConsumo = -1
            sNote = ""
            nGiorni = -1
            bIsIncongruente = False
            bIsIncongruenteForzato = False
            nConsumoTeorico = -1
            bFattSospesa = False
            sNUtente = ""
            tDataLetturaPrec = DateTime.MaxValue
            nLetturaPrec = 0
            bIsPrimaLettura = False
            nIdUtente = -1
            bIsUltimaLettura = False
            nConsumoPrec = -1
            nGiorniPrec = -1
            tDataFatt = DateTime.MaxValue
            nIdStatoLettura = -1
            tDataPassaggio = DateTime.MaxValue
            nIdAnomalia1 = -1
            nIdAnomalia2 = -1
            nIdAnomalia3 = -1
            sLetturaTeorica = ""
            bIsGiroContatore = False
            bIsStorica = False
            bIsStoricizzata = False
            sProvenienza = ""
            nConsumoSubContatore = 0
            nTipoArrotondConsumo = 1
            tDataInserimento = Now
            tDataVariazione = DateTime.MaxValue
            sAzione = ""
        End Sub
    End Class
End Namespace
