class weatherForecast{
    date: string;
    temperatureC: number;
    temperatureF: number;
    summary: string;

    constructor(_date:string, _temperatureC: number, _temperatureF:number, _summary:string){
        this.date = _date;
        this.temperatureC = _temperatureC;
        this.temperatureF = _temperatureF;
        this.summary = _summary;
    }
}