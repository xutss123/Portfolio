//
//  AddCageController.swift
//  SignifyLightControl
//
//  Created by Nagi Elturki on 11/01/2019.
//  Copyright © 2019 issd. All rights reserved.
//

import UIKit
import UICircularProgressRing


class AddCageController: UIViewController {

    var addedCages = [cageClass]()

    
    @IBAction func addCageBtn(_ sender: Any) {
     self.addCage()
      
    }
    @IBOutlet weak var cageName: UITextField!
    
    @IBOutlet weak var fishType: UITextField!
    

    
    override func viewDidLoad() {
        super.viewDidLoad()

        
    }
    
   
    
   
    
    func addCage() {
        
        let myView = UIView(frame: CGRect(x: 0, y: -14, width: 484, height: 475))
     //   myView.backgroundColor = UIColor.darkGray
        let progressRing = UICircularProgressRing(frame: CGRect(x: 35, y: 75, width: 398, height: 298))
     //   let image = UIImageView(frame: CGRect(x: 64, y: 15, width: 268, height: 266))
        let preserBtn = UIButton(frame: CGRect(x: 397, y: 343, width: 45, height: 30))
        let lampBtn = UIButton(frame: CGRect(x: 0, y: 268, width: 45, height: 30))
         let image = UIImageView()
        image.image = UIImage(named: "offLamp")
//        let switchh = UISwitch(frame: CGRect(x: 175, y: 15, width: 49, height: 31))
        let switchh = UISwitch()
        let cageinput = cageClass(name: self.cageName.text!, fish: self.fishType.text!, cage: myView, prograss: progressRing, switchh: switchh, image: image, pretype: " defult")
        self.addedCages.append(cageinput)
    
    }
    
    override func prepare(for segue: UIStoryboardSegue, sender: Any?) {
        if let destination = segue.destination as? ViewController
        {
            destination.cages = self.addedCages
            
        }

    }
    
    
  
    
  
    
}
