Namespace MotoreH2o.Oggetti
    Public Class objContratto
        Private _nIdContratto As Integer
        Private _sIdEnte As String
        Private _nIdIntestatario As Integer
        Private _nIdUtente As Integer
        Private _sCodiceContratto As String
        Private _sDataSottoscrizione As String
        Private _sDataCessazione As String
        Private _sNote As String
        Private _sNoteRichiestaSub As String
        Private _bIsRichiestaSub As Boolean
        Private _oContatore As MotoreH2o.Oggetti.objContatore

        Public Property nIdContratto() As Integer
            Get
                Return _nIdContratto
            End Get
            Set(ByVal Value As Integer)
                _nIdContratto = Value
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
        Public Property sCodiceContratto() As String
            Get
                Return _sCodiceContratto
            End Get
            Set(ByVal Value As String)
                _sCodiceContratto = Value
            End Set
        End Property
        Public Property sDataSottoscrizione() As String
            Get
                Return _sDataSottoscrizione
            End Get
            Set(ByVal Value As String)
                _sDataSottoscrizione = Value
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
        Public Property oContatore() As MotoreH2o.Oggetti.objContatore
            Get
                Return _oContatore
            End Get
            Set(ByVal Value As MotoreH2o.Oggetti.objContatore)
                _oContatore = Value
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
        Public Property sNoteRichiestaSub() As String
            Get
                Return _sNoteRichiestaSub
            End Get
            Set(ByVal Value As String)
                _sNoteRichiestaSub = Value
            End Set
        End Property
        Public Property bIsRichiestaSub() As Boolean
            Get
                Return _bIsRichiestaSub
            End Get
            Set(ByVal Value As Boolean)
                _bIsRichiestaSub = Value
            End Set
        End Property

        Public Sub New()
            nIdContratto = -1
            sIdEnte = ""
            nIdIntestatario = -1
            nIdUtente = -1
            sCodiceContratto = ""
            sDataSottoscrizione = DateTime.MaxValue.ToString
            sDataCessazione = DateTime.MaxValue.ToString
            oContatore = Nothing
            sNote = ""
            sNoteRichiestaSub = ""
            bIsRichiestaSub = False
        End Sub
    End Class
End Namespace