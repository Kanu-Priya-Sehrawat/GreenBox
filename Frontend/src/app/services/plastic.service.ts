import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class PlasticService {
    url = environment.baseUrl;
    constructor(private http: HttpClient) { }
    getAllPlastic() {
        const httpOptions = {
            headers: new HttpHeaders({
                Authorization: 'Bearer '+ localStorage.getItem('token')
            })
        };
        return this.http.get( this.url + '/plastic/list', httpOptions );
    }
    savePlasticData( data: any ) {
        console.log(data);
        const httpOptions = {
            headers: new HttpHeaders({
                Authorization: 'Bearer '+ localStorage.getItem('token')
            })
        };
        return this.http.post( this.url + '/plastic/add', data, httpOptions);
    }
    getTrackOneDay() {
        const httpOptions = {
            headers: new HttpHeaders({
                Authorization: 'Bearer '+ localStorage.getItem('token')
            })
        };
        return this.http.get( this.url + '/plastic/trackday', httpOptions );
    }
    getTrackOneWeek() {
        const httpOptions = {
            headers: new HttpHeaders({
                Authorization: 'Bearer '+ localStorage.getItem('token')
            })
        };
        return this.http.get( this.url + '/plastic/trackweek', httpOptions );
    }
    getTrackOneMonth() {
        const httpOptions = {
            headers: new HttpHeaders({
                Authorization: 'Bearer '+ localStorage.getItem('token')
            })
        };
        return this.http.get( this.url + '/plastic/trackmonth', httpOptions );
    }

}
