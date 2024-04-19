import TopBar from "@/components/topBar";
import { Toaster } from "@/components/ui/toaster";
import About from "@/pages/About";
import Home from "@/pages/Home";
import { Component } from "react";
import { BrowserRouter as Router, Routes, Route } from "react-router-dom";

const AppRoutes = () => {

const routes = [
  {path: '/' , component: Home},
  {path: '/about' , component: About},
]

  return (
    <Router>
      <Toaster />
      <TopBar />
      <Routes>
      {routes.map(({ path, component: Component }, index) => (
            <Route key={index} path={path} element={<Component />} />
          ))}
      </Routes>
    </Router>
  );
};

export default AppRoutes;
