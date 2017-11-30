Feature: Cars

Scenario: ComparisonOfTwoCars
	Given User navigate to cars.com	
		And Navigate to 'Research' page
		And Select random car
	When Save expected info about car
		And Click Search button
		And Click Menu 'Trims'
		And Click Trim comparison button
		And Save actual info about car
	Then Expected and actual car 0 must match
		And Save expected characteristics car 0

	Given Navigate to 'Research' page
		And Select random car
	When Save expected info about car
		And Click Search button
		And Click Menu 'Trims'
		And Click Trim comparison button
		And Save actual info about car
	Then Expected and actual car 1 must match
		And Save expected characteristics car 1

	Given Navigate to Compare cars page
	When Select car 0 
		And Add car 0 for compare
		And Take actual car 0 

		And Click button Add another car
		And Select car 1  
		And Add car 1 for compare 
		And Take actual car 1 

	Then Expected and actual car 0 must match
		And Expected and actual car 1 must match
