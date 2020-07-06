import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {

  public persons: Person[];
  public inspectionPlans: InspectionPlan[];
  public equipments: Equipment[];
  public calibrations: Calibration[];

  public name: string = "test";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.loadPersons();
    this.loadInspectionPlans();
    this.loadEquipments();
    this.loadCalibrations();
  }

  loadPersons() {
    this.http.get<Person[]>(this.baseUrl + 'api/People').subscribe(result => {
      this.persons = result;
      console.log(this.persons);
    }, error => console.error(error));
  }

  loadInspectionPlans() {
    this.http.get<InspectionPlan[]>(this.baseUrl + 'api/InspectionPlans').subscribe(result => {
      this.inspectionPlans = result;
      console.log(this.inspectionPlans);
    }, error => console.error(error));
  };

  loadEquipments() {
    this.http.get<Equipment[]>(this.baseUrl + 'api/Equipments').subscribe(result => {
      this.equipments = result;
      console.log(this.equipments);
    }, error => console.error(error));
  }
  loadCalibrations() {
    this.http.get<Calibration[]>(this.baseUrl + 'api/Calibrations').subscribe(result => {
      this.calibrations = result;
      console.log(this.calibrations);
    }, error => console.error(error));
  }

}

interface Person {
  name: string;
  surname: string;
  phoneNumber: string;
  email: string;
}

interface InspectionPlan {
  description: string;
  temperature: number;
  humidity: number;
  pressure: number;
  personId: number;
}
interface Equipment {
  description: string;
  equipementType: string;
  model: string;
  serialNumber: string;
  calibrationDate: Date;
}

interface Calibration {
  equipmentId: number;
  personId: number;
}
