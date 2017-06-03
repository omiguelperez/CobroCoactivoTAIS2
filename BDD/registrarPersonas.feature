Feature: registrarPersonas
	para que puedan tener acceso al mismo
	como lider
	quiero registrar personas en el sistema

@mytag
Scenario: registro de Personas ExitosoBDD
	Given ya logueado en el sistema
	And estando en el modulo de registro
	And registro la persona
	When al dar clic en el boton registrar
	Then el sistema me mostrara un mensaje
