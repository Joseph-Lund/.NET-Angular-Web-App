import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

const GRAPH_ENDPOINT = 'https://graph.microsoft.com/v1.0/me';

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

  getProfile(): Observable<ProfileType>{
    return this.http.get<ProfileType>(GRAPH_ENDPOINT);
  }
}
