import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FetchDataService {
  private http: HttpClient;
  private baseUrl: string;
  constructor(http:HttpClient, @Inject('BASE_URL') baseUrl: string) { 
    this.http = http;
    this.baseUrl = baseUrl;
  }

  getWeatherForecast(): Observable<WeatherForecast[]>{
    return this.http.get<WeatherForecast[]>(this.baseUrl + 'weatherforecast');
  }
}
