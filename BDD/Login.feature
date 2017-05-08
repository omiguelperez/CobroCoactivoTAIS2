Feature: Login
	para poder acceder al sistema
	como usuario
	quiero ingresar mi usuario y contraseña

@mytag
Scenario: Logueo Exitoso
	Given abrir el navegador
	And ingreso la url del sistema
	And ingreso mi usuario "Secretaria" y mi clave "Secretaria"
	When presione el boton ingresar
	Then mi url sera "http://localhost:9000/#!/Secretaria"

Scenario: Logueo Erroneo
	Given abrir el navegador
	And ingreso la url del sistema
	And ingreso mi usuario "secretaria" y mi clave "olakase"
	When presione el boton ingresar
	Then mi url sera "http://localhost:9000/#!/login"
