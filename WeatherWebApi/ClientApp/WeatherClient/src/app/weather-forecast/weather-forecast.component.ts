import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Forecast } from './weather-forecast.model';
import { ForeCastService } from './weather-forecast.service';

@Component({
  selector: 'app-weather-forecast',
  templateUrl: './weather-forecast.component.html',
  styleUrls: ['./weather-forecast.component.css']
})
export class WeatherForecastComponent implements OnInit {
  form:FormGroup;
  Tempirature:string;
  City:string;
  constructor(private userService: ForeCastService,  private router: Router) { }
  

  ngOnInit(): void {
    this.form=new FormGroup({
      'zipcode': new FormControl(null, [Validators.required])
    
    });
  }
  onSubmit()
  {
   
   
  
    const fromData=this.form.value;
    var zip=fromData.zipcode;
    this.userService.getUser(zip).subscribe((forecat: Forecast) => {
      try {
        console.log(forecat.city);
        this.City=forecat.city;
        this.Tempirature=forecat.tempirature
    }
    catch(e){
      console.log(e);
    }
    
   });


  };


 
}
