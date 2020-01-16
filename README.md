

## Module 3 Capstone - National Park Weather Service

You have been asked to develop a web application for the National Park Weather Service. 

**The requirements for your application are listed below:**



1. As a user of the system, I need the ability to view a list of all national parks from the home page.

    1. The home page should only show a picture of the park, its name, location, and a short summary, 

2. As a user of the system, I need the ability select a park and view additional details about the selected park. All detail described in the Park Data Source needs to be displayed.

3. As a user of the system, once I select a park for viewing I have a way of viewing its 5-day weather forecast. Each daily forecast should provide a recommendation so that the user knows how to prepare for the weather appropriately.

    1. This may be on the same page as the park detail or on a separate page.

    3. The forecast for each park can be obtained from the Weather Forecast database table.
    4. If the daily forecast calls for snow, then tell the user to pack snowshoes.
    5. If the daily forecast calls for rain, then tell the user to pack rain gear and wear waterproof shoes. 
    6. If the daily forecast calls for thunderstorms, tell the user to seek shelter and avoid hiking on exposed ridges.
    7. If the daily forecast calls for sun, tell the user to pack sunblock.
    8. If the temperature is going to exceed 75 degrees, tell the user to bring an extra gallon of water.
    9. If the difference between the high and low temperature exceeds 20 degrees, tell the user to wear breathable layers.
    10. If the temperature is going to be below 20 degrees, make sure to warn the user of the dangers of exposure to frigid temperatures.

4. As a user of the system, I need the ability to change my temperature preference to Celsius or Fahrenheit. My choice should be remembered while browsing the rest of the website.

5. As a user of the system, I need the ability to participate in the daily survey. 

    1. Today’s survey will ask the user to vote on their favorite national park. In additional to selecting a park, they must enter values for a few required fields.

        1. E-mail address, state of residence, and physical activity level (inactive, sedentary, active, extremely active).

    2. Once the survey has been submitted and permanently saved for record, the user is redirected to the survey results page where they see which park leads amongst all survey takers.


### 


### Data Sources

Your application will have access to the following sources of data:


#### Daily Weather File

A daily weather table is provided to the system that provides weather forecast data for the next 5 days. The data columns are as follows: 



<table>
  <tr>
   <td><strong>Field</strong>
   </td>
   <td><strong>Description</strong>
   </td>
  </tr>
  <tr>
   <td>Park Code
   </td>
   <td>A short String that uniquely identifies a park. (see below for list of park codes)
   </td>
  </tr>
  <tr>
   <td>Day
   </td>
   <td>The forecast day.  Today is day 1, tomorrow is day 2, etc.
   </td>
  </tr>
  <tr>
   <td>Low
   </td>
   <td>The expected low temperature in  degrees Fahrenheit
   </td>
  </tr>
  <tr>
   <td>High
   </td>
   <td>The expected high temperature in degrees Fahrenheit
   </td>
  </tr>
  <tr>
   <td>Forecast
   </td>
   <td>The expected weather.  Possible values are:  sunny, partly cloudy, cloudy, rain, thunderstorms, snow
   </td>
  </tr>
</table>



#### Park Data File

A park data table contains information about each park.  The data columns are as follows: 



<table>
  <tr>
   <td><strong>Field</strong>
   </td>
   <td><strong>Description</strong>
   </td>
  </tr>
  <tr>
   <td>Park Code
   </td>
   <td>A short String that uniquely identifies a park. (see below for list of park codes)
   </td>
  </tr>
  <tr>
   <td>Park Name
   </td>
   <td>The name of the park (e.g. “Grand Canyon National Park)
   </td>
  </tr>
  <tr>
   <td>State
   </td>
   <td>The state in which the park is located
   </td>
  </tr>
  <tr>
   <td>Acreage
   </td>
   <td>The size of the park in acres
   </td>
  </tr>
  <tr>
   <td>Elevation in Feet
   </td>
   <td>The park’s elevation above sea level (in feet)
   </td>
  </tr>
  <tr>
   <td>Miles of Trail
   </td>
   <td>The combined length of all hiking trails in the park
   </td>
  </tr>
  <tr>
   <td>Number of Campsites
   </td>
   <td>The total number of campsites available for visitors in the park
   </td>
  </tr>
  <tr>
   <td>Climate
   </td>
   <td>A generate description of the park’s climate (e.g. “Desert”)
   </td>
  </tr>
  <tr>
   <td>Year Founded
   </td>
   <td>The year the park joined the National Park System
   </td>
  </tr>
  <tr>
   <td>Annual Visitor Count
   </td>
   <td>The average number of visitors to the park on a annual basis
   </td>
  </tr>
  <tr>
   <td>Quote
   </td>
   <td>A famous quote related to the park
   </td>
  </tr>
  <tr>
   <td>Quote Source
   </td>
   <td>The person to whom the quote is attributed
   </td>
  </tr>
  <tr>
   <td>Description
   </td>
   <td>A description of the park
   </td>
  </tr>
  <tr>
   <td>Entry Fee
   </td>
   <td>The cost to enter the park in dollars. Starts with a dollar sign. (e.g. $10)
   </td>
  </tr>
  <tr>
   <td>Number of Animal Species
   </td>
   <td>The number of different animal species that can be found within the boundaries of the park
   </td>
  </tr>
</table>



#### Park Codes

Each park has been assigned a unique park code as follows:


<table>
  <tr>
   <td><strong>Park Code</strong>
   </td>
   <td><strong>Park</strong>
   </td>
  </tr>
  <tr>
   <td>GNP
   </td>
   <td>Glacier National Park
   </td>
  </tr>
  <tr>
   <td>GCNP
   </td>
   <td>Grand Canyon National Park
   </td>
  </tr>
  <tr>
   <td>GTNP
   </td>
   <td>Grand Teton National Park
   </td>
  </tr>
  <tr>
   <td>MRNP
   </td>
   <td>Mount Ranier National Park
   </td>
  </tr>
  <tr>
   <td>GSMNP
   </td>
   <td>Great Smoky Mountain National Park
   </td>
  </tr>
  <tr>
   <td>ENP
   </td>
   <td>Everglades National Park
   </td>
  </tr>
  <tr>
   <td>YNP
   </td>
   <td>Yellowstone National Park
   </td>
  </tr>
  <tr>
   <td>YNP2
   </td>
   <td>Yosemite National Park
   </td>
  </tr>
  <tr>
   <td>CVNP
   </td>
   <td>Cuyahoga Valley National Park
   </td>
  </tr>
  <tr>
   <td>RMNP
   </td>
   <td>Rocky Mountain National Park
   </td>
  </tr>
</table>
