import styled from 'styled-components';
import { useNavigate } from 'react-router-dom';

const StyledPageNotFound = styled.main`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  gap: 2rem;
  height: 100dvh;
`;

export const PageNotFound = () => {
  const navigate = useNavigate();

  return (
    <StyledPageNotFound>
      <h3>The page you are looking for could not be found</h3>
      <button
        onClick={() => {
          navigate('/login');
        }}
      >
        &larr; Go back
      </button>
    </StyledPageNotFound>
  );
};
