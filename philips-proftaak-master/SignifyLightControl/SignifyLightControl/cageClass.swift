//
//  cageClass.swift
//  collectionView
//
//  Created by Nagi Elturki on 08/01/2019.
//  Copyright © 2019 ISSD. All rights reserved.
//

import Foundation
import UIKit
import UICircularProgressRing
// i remove nscoding
class cageClass: NSObject{
  
    
  
   
    
    var cageView:UIView
    var cagePrograss:UICircularProgressRing
    var cageSwitch:UISwitch
    var cageImage:UIImageView
    var prograssValue:Int
    var cageName:String
    var fishType:String
    
    
    
   
   
    init(name:String, fish:String, cage:UIView, prograss:UICircularProgressRing, switchh:UISwitch, image:UIImageView) {
        self.cageName = name
        self.fishType = fish
        self.cageView = cage
        self.cagePrograss = prograss
        self.cageSwitch = switchh
        self.cageImage = image
        self.prograssValue = 0
        
        //vjfnvfjvnfdjvndfkj
    }
    
   


    
}//end of the class
