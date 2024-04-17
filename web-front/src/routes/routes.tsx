import { Toaster } from "@/components/ui/toaster";
import About from "@/pages/About";
import Home from "@/pages/Home"
import { BrowserRouter as Router, Routes, Route } from "react-router-dom"

const AppRoutes = () => {
    return(
        <Router>
            <Toaster />
            <Routes>
                <Route path="/" element= {<Home />}/> 
                <Route path="/about" element= {<About />}/> 

            </Routes>
        </Router>
    )
}

export default AppRoutes;