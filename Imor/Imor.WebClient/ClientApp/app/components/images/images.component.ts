import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
	selector: 'images',
	templateUrl: './images.component.html',
	styleUrls: ['./images.component.css']
})
export class ImagesComponent {
	public images: ImorImage[];

	constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
		http.get(baseUrl + 'api/images').subscribe(result => {

			this.images = result.json() as ImorImage[];

		}, error => console.error(error));
	}
}

interface ImorImage {
	description: string;
	uri: string;
	content: string;
}
