Feature: RegistrarCartera
	para poder realizar los respectivos cobros
	como secretaria
	yo quiero registrar la cartera

@mytag
Scenario: Registar CarteraBDD
	Given ya logueada dentro del sistema
	And presiono la opcion registar cartera
	And luego clic en agregar nueva deuda
	And relleno el formulario
	When presione el boton registrar
	Then el sistema me arroja el mensaje "registrado correctamente"
