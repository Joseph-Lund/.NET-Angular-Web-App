import { Component, Inject, OnInit } from '@angular/core';
import { FetchDataService } from './fetch-data.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {

  public forecasts: WeatherForecast[];
  private fetchDataService: FetchDataService;

  constructor(fetchDataService: FetchDataService) {
    this.fetchDataService = fetchDataService;
  }


  ngOnInit(): void {
    this.fetchDataService.getWeatherForecast().subscribe(
      (forcastListResults: WeatherForecast[]) =>{
        this.forecasts = forcastListResults;
      },
      (error: any)=>{
        //TODO: add popup to show there was an error
        console.error("getWeatherForecast Error: ", error);
      }
      );
  }
}
