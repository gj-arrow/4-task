Feature: Cars

Scenario: ComparisonOfTwoCars
	Given User navigate to cars.com
	
	When Navigate to Research
		And Select random car 
		And Click Search button
		And Click first trim
		And Take info about car
	Then Is right charachteristics car 0

	When Take info about engine and transmission 
		And Navigate to Research
		And Select random car 
		And Click Search button
		And Click first trim
		And Take info about car 
	Then Is right charachteristics car 1

	When Take info about engine and transmission 
		And Navigate to Compare cars
		And Add first car for compare
		And Add second car for compare 
	Then Is right are selected cars charachteristics