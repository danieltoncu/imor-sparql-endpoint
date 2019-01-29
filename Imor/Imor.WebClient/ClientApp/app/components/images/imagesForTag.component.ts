import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Http } from '@angular/http';

@Component({
	selector: 'imagesForTag',
	templateUrl: './imagesForTag.component.html',
	styleUrls: ['./images.component.css']
})

export class ImagesForTagComponent {
	public images: ImorImage[];

	OnInit(route: ActivatedRoute) {

		route.queryParams.subscribe(val => console.log(val));
	}

	constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {

		http.get(baseUrl + 'api/images/byTag?tagUri=http%3A%2F%2Fwww.semanticweb.org%2FImagesOntology%23MountainsTag').subscribe(result => {

			this.images = result.json() as ImorImage[];

		}, error => console.error(error));
	}
}

interface ImorImage {
	description: string;
	uri: string;
	content: string;
}
