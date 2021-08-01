import { Component, Inject, OnInit } from '@angular/core';
import { FetchDataService } from './fetch-data.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent implements OnInit {
  profile!: ProfileType;
  public forecasts: WeatherForecast[];
  private fetchDataService: FetchDataService;

  constructor(fetchDataService: FetchDataService) {
    this.fetchDataService = fetchDataService;
  }


  ngOnInit(): void {
    this.getProfile();
    this.getWeatherForecast();
  }

  getProfile(): void{
    this.fetchDataService.getProfile().subscribe(
      (profileType: ProfileType) =>{
        this.profile = profileType;
        this.getWeatherForecast();
      },
      (error: any)=>{
        //TODO: add popup to show there was an error
        console.error("getProfile Error: ", error);
      }
      );
  }

  getWeatherForecast(): void{
    this.fetchDataService.getWeatherForecast().subscribe(
      (weatherForcast: WeatherForecast[]) =>{
        this.forecasts = weatherForcast;
      },
      (error: any)=>{
        //TODO: add popup to show there was an error
        console.error("getWeatherForecast Error: ", error);
      }
      );
  }
}
