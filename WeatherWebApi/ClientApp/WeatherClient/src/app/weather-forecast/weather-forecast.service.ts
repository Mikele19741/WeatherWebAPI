import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ForeCastService{

    constructor(public  http: HttpClient) {
      
    }
    getUser(zipcode: string) {   
      return this.http.get('http://localhost:34762/api/weatherbyzipcode?zip='+zipcode)
    }

}