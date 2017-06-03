Feature: Login
	para poder acceder al sistema
	como usuario
	quiero ingresar mi usuario y contraseña

@mytag
Scenario Outline: Logueo ExitosoBDD
	Given abrir el navegador
	And ingreso la url del sistema
	And ingreso mis credenciales <usuario> and <clave>
	When presione el boton ingresar
	Then mi url cambiara de acuerdo a mi rol <url>
	Examples: 
	| usuario    | clave        | url                                 |
	| secretaria | secretaria1* | http://localhost:9999/#!/Secretaria |
	| lider      | lider1*      | http://localhost:9999/#!/Lider      |
	| abogado    | abogado1*    | http://localhost:9999/#!/Abogado    |

Scenario: Logueo ErroneoBDD
	Given abrir el navegador
	And ingreso la url del sistema
	And ingreso mi usuario "secretaria" y mi clave "olakase"
	When presione el boton ingresar
	Then mi url sera "http://localhost:9999/#!/login"
