//
//  ViewController.swift
//  locations
//
//  Created by Alexandra Turcu on 10/01/2019.
//  Copyright © 2019 Fontys. All rights reserved.
//

import UIKit
import MapKit

class ViewController: UIViewController, MKMapViewDelegate {

    var lm:CLLocationManager!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        mapView.delegate = self

        lm = CLLocationManager()
        checkLocationAuthorizationStatus()
        let initialRegion = MKCoordinateRegion(center: CLLocationCoordinate2D(latitude:51.452113, longitude:5.482211),
                                               span: MKCoordinateSpan(latitudeDelta: 0.001640554407, longitudeDelta: 0.0012325287995))
        let define = MKMapPoint(x: 51, y: 5)
        let sizemap = MKMapSize(width: 100, height: 400)
       let rectangle = MKMapRect(origin: define, size: sizemap)
        mapView.region = initialRegion
        mapView.showsUserLocation = true
        mapView.showsCompass = true
        mapView.setUserTrackingMode(.followWithHeading, animated: false)
        let overlay = ImageOverlay(image: #imageLiteral(resourceName: "forAlexandra"), rect: rectangle)
        mapView.add(overlay , level: MKOverlayLevel.aboveLabels)
        // Do any additional setup after loading the view, typically from a nib.
    }
    func checkLocationAuthorizationStatus() {
        if CLLocationManager.authorizationStatus() == .authorizedWhenInUse {
            lm.startUpdatingHeading()
        } else {
            lm.requestWhenInUseAuthorization()
            
        }
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }

    @IBOutlet weak var mapView: MKMapView!
    
    class ImageOverlay : NSObject, MKOverlay {
        
        let image:UIImage
        let boundingMapRect: MKMapRect
        let coordinate:CLLocationCoordinate2D
        
        init(image: UIImage, rect: MKMapRect) {
            self.image = image
            self.boundingMapRect = rect
            self.coordinate = CLLocationCoordinate2D(latitude:51.452113, longitude:5.482211)
        }
    }
    
    class ImageOverlayRenderer : MKOverlayRenderer {
        
        override func draw(_ mapRect: MKMapRect, zoomScale: MKZoomScale, in context: CGContext) {
            
            guard let overlay = self.overlay as? ImageOverlay else {
                return
            }
            
            let rect = self.rect(for: overlay.boundingMapRect)
            
            UIGraphicsPushContext(context)
            overlay.image.draw(in: rect)
            UIGraphicsPopContext()
        }
    }
}

