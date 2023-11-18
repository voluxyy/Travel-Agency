# Travel Agency

Application réalisé par Anael Lasserre et Florent Detres.

___
## Backend

Le backend est donc en csharp, nous avons fait la totalité des objectifs que vous nous avez donné ainsi que des suppléments afin de simuler un vrai projet d'agence de voyage.

Pour ce qui est des bonus : <!-- TODO: Bonus csharp speech -->

### Modèle de données :
* Categories :
    * Id
    * Title

* Comments :
    * Id
    * Text
    * UserId
    * DestinationId

* Continents :
    * Id
    * Title

* Countries :
    * Id
    * Title
    * ContinentId

* Destinations :
    * Id
    * AverageRate
    * Capital
    * City
    * ToDo
    * CategoryId
    * CountryId

* Events :
    * Id
    * Date
    * Title
    * Description
    * DestinationId

* Favories :
    * Id
    * IsFavorite
    * UserId
    * DestinationId

* Rates :
    * Id
    * Number
    * UserId
    * DestinationId

* TravelTypes :
    * Id
    * Title

* Travels :
    * Id
    * DateStart
    * DateEnd
    * DestinationId
    * TravelTypeId
    * UserId

* Users :
    * Id
    * LastName
    * FirstName
    * Password
    * Birthday
    * Description

* Visits :
    * Id
    * IsVisited
    * DateVisited
    * DestinationId
    * UserId

## Angular

<!-- TODO: Angular speech -->
