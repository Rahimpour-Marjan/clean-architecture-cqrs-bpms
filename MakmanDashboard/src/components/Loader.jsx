import styled from 'styled-components';

const LoaderStyled = styled.div`
  display: flex;
  justify-content: center;
  align-items: center;

  .loader {
    width: 50px;
    aspect-ratio: 1;
    border-radius: 50%;
    border: 8px solid lightblue;
    border-right-color: var(--primary-900);
    animation: spin 1s infinite linear;
  }

  @keyframes spin {
    to {
      transform: rotate(1turn);
    }
  }
`;

export const Loader = () => {
  return (
    <LoaderStyled>
      <div className='loader' />
    </LoaderStyled>
  );
};
