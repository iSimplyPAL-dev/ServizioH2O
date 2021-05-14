Imports System.Runtime.Remoting.Channels
Imports System.Runtime.Remoting.Channels.Http
Imports System.Runtime.Remoting.Channels.Tcp
Imports System.Runtime.Remoting
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters
Imports System.Runtime.Remoting.ObjRef
Imports System.Threading
Imports System.Collections
Imports System.ServiceProcess
Imports System.Configuration

Imports log4net
Imports log4net.Config
Imports System.IO

Namespace ServizioMotoreH2OSRV
    ''' <summary>
    ''' Classe di iniziazione del servizio.
    ''' 
    ''' Il servizio si occupa di calcolare il dovuto H2O.
    ''' </summary>
    Public Class ServizioMotoreH2O
        Inherits System.ServiceProcess.ServiceBase
        Private chan As HttpChannel
        Private Shared ReadOnly log As ILog = LogManager.GetLogger(GetType(ServizioMotoreH2O))
        'true --> quando si deve buildare il servizio
        'false --> quando si vuole lanciare in console per il debug
        Private Shared _runService As Boolean = False

#Region " Component Designer generated code "

        Public Sub New()
            MyBase.New()

            ' This call is required by the Component Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call

        End Sub

        'UserService overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        ' The main entry point for the process
        <MTAThread()>
        Shared Sub Main()
            Dim ServicesToRun() As System.ServiceProcess.ServiceBase

            ' More than one NT Service may run within the same process. To add
            ' another service to this process, change the following line to
            ' create a second service object. For example,
            '
            '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
            '
            If (_runService) Then
                ServicesToRun = New System.ServiceProcess.ServiceBase() {New ServizioMotoreH2O}
                System.ServiceProcess.ServiceBase.Run(ServicesToRun)
            Else
                Dim oServizio As New ServizioMotoreH2O
                oServizio.OnStart(Nothing)
                Console.WriteLine("3...2...1...si parte ^.^")
                Console.ReadLine()
            End If
        End Sub

        'Required by the Component Designer
        Private components As System.ComponentModel.IContainer

        ' NOTE: The following procedure is required by the Component Designer
        ' It can be modified using the Component Designer.  
        ' Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            components = New System.ComponentModel.Container
            Me.ServiceName = "ServizioMotoreH2O"
        End Sub

#End Region

        Protected Overrides Sub OnStart(ByVal args() As String)
            ' Add code here to start your service. This method should set things
            ' in motion so your service can do its work.
            Dim pathfileinfo As String = ConfigurationSettings.AppSettings("pathfileconflog4net").ToString()
            Dim fileconfiglog4net As New FileInfo(pathfileinfo)
            XmlConfigurator.ConfigureAndWatch(fileconfiglog4net)

            RegisterService()
        End Sub

        Protected Overrides Sub OnStop()
            ' Add code here to perform any tear-down necessary to stop your service.
            ChannelServices.UnregisterChannel(chan)
        End Sub

        Private Shared Sub RegisterService()
            'Try
            ' Use the configuration file. 
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)

            ' Check to see if we have full errors. 

            'string s = "Errore eccezioni"; 
            If RemotingConfiguration.CustomErrorsEnabled(False) = True Then
            End If

            Console.WriteLine("Inizializzazione Servizio Remoto")
            Dim clientProvider As New BinaryClientFormatterSinkProvider
            Dim serverProvider As New BinaryServerFormatterSinkProvider
            serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full
            Dim props As IDictionary = New Hashtable
            props("port") = ConfigurationSettings.AppSettings("TCP_PORT").ToString()
            '50010; 
            'props["typeFilterLevel"] = TypeFilterLevel.Full; 
            Dim chan As New TcpChannel(props, clientProvider, serverProvider)

            props("port") = ConfigurationSettings.AppSettings("HTTP_PORT").ToString()
            ' 50011; 
            Dim clientProviderSoap As New SoapClientFormatterSinkProvider
            Dim serverProviderSoap As New SoapServerFormatterSinkProvider
            serverProviderSoap.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full

            Dim httpChan As New HttpChannel(props, Nothing, Nothing)

            log.Debug("Registrazione Canale")
            ChannelServices.RegisterChannel(chan)
            ChannelServices.RegisterChannel(httpChan)
            'ChannelServices.RegisterChannel(httpChan2); 

            RemotingConfiguration.RegisterWellKnownServiceType(GetType(MotoreH2O), "MotoreH2O.rem", WellKnownObjectMode.SingleCall)
            log.Debug("Registrato MotoreH2O")

            '' Use the configuration file. 
            'RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile)

            '' Check to see if we have full errors. 

            ''string s = "Errore eccezioni"; 
            'If RemotingConfiguration.CustomErrorsEnabled(False) = True Then
            'End If

            'Console.WriteLine("Inizializzazione Servizio Remoto")
            'Dim clientProvider As New BinaryClientFormatterSinkProvider
            'Dim serverProvider As New BinaryServerFormatterSinkProvider
            'serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full
            ''50010; 
            ''props["typeFilterLevel"] = TypeFilterLevel.Full; 

            '' 50011; 


            'Dim httpChan As New HttpChannel(props, Nothing, Nothing)

            'log.Debug("Registrazione Canale")
            'ChannelServices.RegisterChannel(httpChan)
            'ChannelServices.RegisterChannel(httpChan2); 

            'Catch Err As Exception
            '    Throw New Exception(Err.Message)
            'End Try
        End Sub
    End Class
End Namespace