import AppRoutes from "./routes/routes";
import "../css/globals.css";
import { ThemeProvider } from "@/components/themeProvider";

function App() {
  return (
    <>
      <ThemeProvider>
        <AppRoutes />
      </ThemeProvider>
    </>
  );
}

export default App;